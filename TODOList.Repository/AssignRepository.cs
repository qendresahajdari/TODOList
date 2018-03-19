using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TODOList.Domain;
using System.Data.Entity;

namespace TODOList.Repository
{
    public class AssignRepository : IAssignRepository, IDisposable
    {

        private TodoListContext context;

        public AssignRepository(TodoListContext context)
        {
            this.context = context;
        }

        public void Create(Assign assign)
        {
            context.Assignes.Add(assign);
        }

        public void Delete(int Id)
        {
            Assign assign= context.Assignes.Find(Id);
            context.Assignes.Remove(assign);
        }

        public IEnumerable<Assign> GetAll()
        {
            return context.Assignes.ToList();
        }

        public Assign GetByID(int Id)
        {
            return context.Assignes.Find(Id);
        }

        public void Update(Assign assign)
        {
            context.Entry(assign).State = EntityState.Modified;
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
