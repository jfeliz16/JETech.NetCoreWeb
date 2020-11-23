using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.NetCoreWeb
{
    public class ActionQueryArgs<t>
    {
        public PageArgs PageArgs { get; set; }
        public t Model { get; set; }
    }

    public class PageArgs 
    {
        public int? Size { get; set; }
        public int? Num { get; set; }
        public int? Skip { get; set; }
    }
}
