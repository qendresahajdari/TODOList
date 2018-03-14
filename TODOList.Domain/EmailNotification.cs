using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class EmailNotification : Notification
    {
        protected override void Send()
        {
            throw new NotImplementedException();
        }
        public string Name { get; set; }

        public EmailNotification(string body, string to, string subject)
        {
            this.Body = body;
            this.To = to;
            this.Subject = subject;
        }
    }
}
