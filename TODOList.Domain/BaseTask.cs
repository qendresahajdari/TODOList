using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public abstract class BaseTask
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public ProjectTaskPriority Priority { get; set; }
        public List<Assign> Assigns { get; set; }
        public int? PersonId { get; set; }
        public Project Project { get; set; }
        public Person Person { get; set; }
        public TaskStatus Status { get; set; }

    }

    public enum ProjectTaskPriority : int
    {
        LOW = 1,
        MEDIUM = 2,
        HIGH = 3
        
    }
    public enum TaskStatus
    {
        Pending=1,
        Assigned = 2,
        Completed =3
       
    }

}
