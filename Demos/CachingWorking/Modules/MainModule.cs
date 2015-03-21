using Nancy;
using Caching.CachingExtensions;
using System;

namespace Caching.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = x => View["Index.cshtml", DateTime.Now.ToString()];

            Get["/cached"] = x =>
            {
                Context.EnableOutputCache(30);
                return View["Payload.cshtml", DateTime.Now.ToString()];
            };

            Get["/uncached"] = x =>
            {
                Context.DisableOutputCache();
                return View["Payload.cshtml", DateTime.Now.ToString()];
            };
        }
    }
}