using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class SoftwareTask : BaseTask
    {
        public string Module { get; set; }
        public string Version { get; set; }

    }
}
