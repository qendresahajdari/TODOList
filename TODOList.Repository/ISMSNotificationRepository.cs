using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    interface ISmsNotificationRepository : IDisposable
    {
        IEnumerable<SmsNotification> GetAll();
        SmsNotification GetByID(int Id);
        void Create(SmsNotification smsNotification);
        void Delete(int Id);
        void Update(SmsNotification smsNotification);
    }
}
