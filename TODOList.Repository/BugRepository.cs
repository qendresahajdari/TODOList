using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TODOList.Domain;
using System.Data.Entity;

namespace TODOList.Repository
{
    public class BugRepository : IBugRepository, IDisposable
    {

        private TodoListContext context;

        public BugRepository(TodoListContext context)
        {
            this.context = context;
        }

        public void Create(Bug bug)
        {
            context.Bugs.Add(bug);
        }

        public void Delete(int Id)
        {
            Bug bug = context.Bugs.Find(Id);
            context.Bugs.Remove(bug);
        }

        public IEnumerable<Bug> GetAll()
        {
            return context.Bugs.ToList();
        }

        public Bug GetByID(int Id)
        {
            return context.Bugs.Find(Id);
        }

        public void Update(Bug bug)
        {
            context.Entry(bug).State = EntityState.Modified;
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
