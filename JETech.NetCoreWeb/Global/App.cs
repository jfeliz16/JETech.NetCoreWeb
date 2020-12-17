using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.NetCoreWeb.Global
{
    public class App
    {
        public static DbContext CurrentDbContext { get; set; }
    }
}
