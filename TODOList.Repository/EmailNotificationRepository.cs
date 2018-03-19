using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TODOList.Domain;
using System.Data.Entity;

namespace TODOList.Repository
{
    public class EmailNotificationRepository : IEmailNotificationRepository, IDisposable
    {

        private TodoListContext context;

        public EmailNotificationRepository(TodoListContext context)
        {
            this.context = context;
        }

        public void Create(EmailNotification emailNotification)
        {
            context.EmailNotifications.Add(emailNotification);
        }

        public void Delete(int Id)
        {
            EmailNotification emailNotification = context.EmailNotifications.Find(Id);
            context.EmailNotifications.Remove(emailNotification);
        }

        public IEnumerable<EmailNotification> GetAll()
        {
            return context.EmailNotifications.ToList();
        }

        public EmailNotification GetByID(int Id)
        {
            return context.EmailNotifications.Find(Id);
        }

        public void Update(EmailNotification emailNotification)
        {
            context.Entry(emailNotification).State = EntityState.Modified;
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
