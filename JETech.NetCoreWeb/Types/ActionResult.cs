using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JETech.NetCoreWeb.Types
{
    public class ActionResult<t>
    {
        public t Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
