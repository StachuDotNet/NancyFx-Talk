using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Live.FirstDemo.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/hello/{there}"] = _ => String.Format("Hello, {0}", _.there);

            Get["/view"] = _ => View["index"];
        }

        private dynamic FuncEquivalent(dynamic input)
        {
            return "Hello, " + input.there;
        }
    }
}