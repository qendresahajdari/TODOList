using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class Bug : Software
    {
        public BugType BugType { get; set; }    

    }
    public enum BugType
    {
        CRITICAL = 1,
        MAJOR = 2
    }

}
