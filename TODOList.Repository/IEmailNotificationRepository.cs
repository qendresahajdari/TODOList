using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    interface IEmailNotificationRepository : IDisposable
    {
        IEnumerable<EmailNotification> GetAll();
        EmailNotification GetByID(int Id);
        void Create(EmailNotification emailNotification);
        void Delete(int Id);
        void Update(EmailNotification emailNotification);
    }
}
