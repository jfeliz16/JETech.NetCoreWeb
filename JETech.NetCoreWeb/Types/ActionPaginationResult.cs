using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.NetCoreWeb.Types
{
    public class ActionPaginationResult<t> : ActionResult<t>
    {        
        public int TotalCount { get; set; }
        public int GroupCount { get; set; }
    }
}
