﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Domain
{
    public class User : Person
    {
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
