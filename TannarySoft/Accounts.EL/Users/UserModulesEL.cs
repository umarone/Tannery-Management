﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class UserModulesEL : ModulesEL
    {
        public Guid IdUserModule 
        { 
            get; 
            set; 
        }
        public string ModuleAction
        {
            get;
            set;
        }
        
    }
}
