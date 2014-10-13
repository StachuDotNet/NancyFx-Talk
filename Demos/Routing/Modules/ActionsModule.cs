using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nancy.ModelBinding;

namespace Routing.Modules
{
    public class ActionsModule : NancyModule
    {
        public ActionsModule()
        {
            Get["/"] = _ =>
            {
                var model = this.Bind<ModelToBindTo>();

                // validation would happen here.

                // call a service, and prepare some data
                var dataComputed = new object();
                
                // If you return an object as-is, 
                //   it will automatically be serialized to XML, JSON,
                //   or some other large payload
                return dataComputed;
            };

            // Using the Response object manually to override what would automatically happen
            Get["/"] = _ => {
                return Response.AsJson("data", HttpStatusCode.OK);
            };

            // Manual content negotiation.
            Get["/"] = _ =>
            {
                return Negotiate
                    .WithModel(new { FirstName = "Nancy " })
                    .WithMediaRangeModel("text/html", new { FirstName = "Nancy fancy pants" })
                    .WithView("negotiatedview")
                    .WithHeader("X-Custom", "SomeValue");
            };
        }
    }
}