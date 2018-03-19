using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TODOList.Domain;
using System.Data.Entity;

namespace TODOList.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {

        private TodoListContext context;

        public UserRepository(TodoListContext context)
        {
            this.context = context;
        }

        public void Create(User user)
        {
            context.Users.Add(user);
        }

        public void Delete(int Id)
        {
            User user = context.Users.Find(Id);
            context.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetByID(int Id)
        {
            return context.Users.Find(Id);
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
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
