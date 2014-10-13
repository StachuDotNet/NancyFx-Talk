using Nancy;
using Caching.CachingExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caching.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = x =>
            {
                return View["Index.cshtml", DateTime.Now.ToString()];
            };

            Get["/cached"] = x =>
            {
                this.Context.EnableOutputCache(30);
                return View["Payload.cshtml", DateTime.Now.ToString()];
            };

            Get["/uncached"] = x =>
            {
                this.Context.DisableOutputCache();
                return View["Payload.cshtml", DateTime.Now.ToString()];
            };
        }
    }
}