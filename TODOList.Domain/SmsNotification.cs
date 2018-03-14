using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class SmsNotification : Notification
    {
      
        protected override void Send()
        {
            throw new NotImplementedException();
        }
        public SmsNotification(string body, string to)
        {
            this.Body = body;
            this.To = to;
        }
    }
}
