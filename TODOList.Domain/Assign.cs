using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class Assign
    {
        public int Id { get; set; }
        public int BaseTaskId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }

        public bool Status{ get; set; }
        public DateTime Date{ get; set; }
        public Person Person { get; set; }
        public BaseTask BaseTask { get; set; }

    }
  

}
