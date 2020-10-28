using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.NetCoreWeb.Controls.Menu
{
    public class MenuItem
    {
        public string text { get; set; }
        public bool disabled { get; set; }
        public string icon { get; set; }        
        public IEnumerable<MenuItem> items { get; set; }
    }
}
