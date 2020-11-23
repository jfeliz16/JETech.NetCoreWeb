using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.NetCoreWeb
{
    public class ActionPaginationResult<t> : ActionResult<t>
    {        
        public int TotalCount { get; set; }
        public int GroupCount { get; set; }
    }

    public class ActionResult<t>
    {
        public t Data { get; set; }      
    }
}
