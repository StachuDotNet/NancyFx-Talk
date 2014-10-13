using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ModelBinding;

namespace Routing
{
    public class MethodsModule : NancyModule
    {
        public MethodsModule()
        {
            // Get
            Get["/route/path"] = _ => "Do stuff";

            // Upsert
            Post["/"] = _ => {
                var model = this.Bind<ModelToBindTo>();
                return model;
            };

            // Delete
            Delete["/"] = _ => {
                var model = this.Bind<ModelToBindTo>();
                return model;
            };

            // total replacement of existing
            Put["/"] = _ => {
                var model = this.Bind<ModelToBindTo>();
                return model;
            };

            // modify existing
            Patch["/"] = _ =>
            {
                var model = this.Bind<ModelToBindTo>();
                return model;
            };

            // Not used often...
            Options["/"] = _ => new object{};
        }
    }

    public class ModelToBindTo
    {

    }
}