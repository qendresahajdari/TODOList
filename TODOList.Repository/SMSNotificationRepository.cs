using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TODOList.Domain;
using System.Data.Entity;

namespace TODOList.Repository
{
    public class SmsNotificationRepository : ISmsNotificationRepository, IDisposable
    {

        private TodoListContext context;

        public SmsNotificationRepository(TodoListContext context)
        {
            this.context = context;
        }

        public void Create(SmsNotification smsNotification)
        {
            context.SmsNotifications.Add(smsNotification);
        }

        public void Delete(int Id)
        {
            SmsNotification smsNotification = context.SmsNotifications.Find(Id);
            context.SmsNotifications.Remove(smsNotification);
        }

        public IEnumerable<SmsNotification> GetAll()
        {
            return context.SmsNotifications.ToList();
        }

        public SmsNotification GetByID(int Id)
        {
            return context.SmsNotifications.Find(Id);
        }

        public void Update(SmsNotification smsNotification)
        {
            context.Entry(smsNotification).State = EntityState.Modified;
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
