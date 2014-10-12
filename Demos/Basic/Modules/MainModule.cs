using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basic.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = _ => "<a href='/secure'>Enter</a>";
        }
    }
}