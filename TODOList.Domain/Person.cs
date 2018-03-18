using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TODOList.Domain
{
    public abstract class Person 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber{ get; set; }
        public List<Assign> Assigns { get; set; }
        public List<BaseTask> BaseTasks { get; set; }

    }
}
