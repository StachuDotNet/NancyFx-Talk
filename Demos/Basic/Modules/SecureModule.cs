using Nancy;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basic.Modules
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
            : base("/secure")
        {
            this.RequiresAuthentication();

            Get["/"] = x =>
            {
                return "Hello " + this.Context.CurrentUser.UserName;
            };
        }
    }
}