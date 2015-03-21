using Forms.UserData;
using Nancy;
using Nancy.Extensions;
using System;
using System.Dynamic;
using Nancy.Authentication.Forms;

namespace Forms.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = x => View["index"];

            Get["/login"] = x =>
            {
                dynamic model = new ExpandoObject();
                model.Errored = Request.Query.error.HasValue;

                return View["login", model];
            };

            Post["/login"] = x =>
            {
                var userGuid = UserDatabase.ValidateUser((string)Request.Form.Username, (string)Request.Form.Password);

                if (userGuid == null)
                    return Context.GetRedirect("~/login?error=true&username=" + (string)Request.Form.Username);

                DateTime? expiry = null;
                if (Request.Form.RememberMe.HasValue)
                    expiry = DateTime.Now.AddDays(7);

                return this.LoginAndRedirect(userGuid.Value, expiry);
            };

            Get["/logout"] = x => this.LogoutAndRedirect("~/");
        }
    }
}