using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public abstract class Notification 
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        protected string Body { get; set; }
        public bool IsSent { get; set; }
      
        abstract protected void Send();

        protected int GetAll() {
            return 1;
        }
  
    }

}
