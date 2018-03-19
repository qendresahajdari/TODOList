using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TODOList.Domain;
using System.Data.Entity;

namespace TODOList.Repository
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {

        private TodoListContext context;

        public ProjectRepository(TodoListContext context)
        {
            this.context = context;
        }

        public void Create(Project project)
        {
            context.Projects.Add(project);
        }

        public void Delete(int Id)
        {
            Project project = context.Projects.Find(Id);
            context.Projects.Remove(project);
        }

        public IEnumerable<Project> GetAll()
        {
            return context.Projects.ToList();
        }

        public Project GetByID(int Id)
        {
            return context.Projects.Find(Id);
        }

        public void Update(Project project)
        {
            context.Entry(project).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
