using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routing.Modules
{
    public class ConditionsModule : NancyModule
    {
        public ConditionsModule()
        {
            // Conditions must be of the form Func<NancyContext, bool> !

            Post["/login", (ctx) => ctx.Request.Form.remember] = _ =>
            {
                return "Handling code when remember is true!";
            };

            Post["/login", (ctx) => !ctx.Request.Form.remember] = _ =>
            {
                return "Handling code when remember is false!";
            };
        }
    }
}