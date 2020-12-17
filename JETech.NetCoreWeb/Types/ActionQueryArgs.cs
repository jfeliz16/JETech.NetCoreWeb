﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JETech.NetCoreWeb.Types
{
    public class ActionQueryArgs<t>
    {
        public PageArgs PageArgs { get; set; }
        public t Model { get; set; }
        public Expression<Func<t, bool>> Condiction { get; set; }
        public string CondictionString { get; set; }
    }

    public class PageArgs 
    {
        public int? Size { get; set; }
        public int? Num { get; set; }
        public int? Skip { get; set; }
    }
}
