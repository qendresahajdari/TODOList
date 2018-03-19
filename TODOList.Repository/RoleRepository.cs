using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TODOList.Domain;
using System.Data.Entity;

namespace TODOList.Repository
{
    public class RoleRepository : IRoleRepository, IDisposable
    {

        private TodoListContext context;

        public RoleRepository(TodoListContext context)
        {
            this.context = context;
        }

        public void Create(Role role)
        {
            context.Roles.Add(role);
        }

        public void Delete(int Id)
        {
            Role role = context.Roles.Find(Id);
            context.Roles.Remove(role);
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Roles.ToList();
        }

        public Role GetByID(int Id)
        {
            return context.Roles.Find(Id);
        }

        public void Update(Role role)
        {
            context.Entry(role).State = EntityState.Modified;
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
