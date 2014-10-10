using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello, I'm Nancy!";

            Get["/{something}"] = ctx => "Hello, " + ctx.something + "!";

            Get["view"] = _ => View["index"];
        }
    }
}