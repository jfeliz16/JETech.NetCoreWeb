using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JETech.NetCoreWeb.Types
{
    public class ActionArgs<t>
    {        
        public t Model { get; set; }
    }
}
