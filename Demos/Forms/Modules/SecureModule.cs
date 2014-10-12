using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using Nancy.Security;
using System.Web;
using Forms.UserData;

namespace Forms.Modules
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
            : base("/secure")
        {
            this.RequiresAuthentication();

            Get["/"] = x =>
            {
                var model = new UserModel(this.Context.CurrentUser.UserName);
                return View["secure.cshtml", model];
            };
        }
    }
}