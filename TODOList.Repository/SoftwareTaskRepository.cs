using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TODOList.Domain;
using System.Data.Entity;

namespace TODOList.Repository
{
    public class SoftwareTaskRepository : ISoftwareTaskRepository, IDisposable
    {

        private TodoListContext context;

        public SoftwareTaskRepository(TodoListContext context)
        {
            this.context = context;
        }

        public void Create(SoftwareTask softwareTask)
        {
            context.SoftwareTasks.Add(softwareTask);
        }

        public void Delete(int Id)
        {
            SoftwareTask softwareTask = context.SoftwareTasks.Find(Id);
            context.SoftwareTasks.Remove(softwareTask);
        }

        public IEnumerable<SoftwareTask> GetAll()
        {
            return context.SoftwareTasks.ToList();
        }

        public SoftwareTask GetByID(int Id)
        {
            return context.SoftwareTasks.Find(Id);
        }

        public void Update(SoftwareTask softwareTask)
        {
            context.Entry(softwareTask).State = EntityState.Modified;
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
