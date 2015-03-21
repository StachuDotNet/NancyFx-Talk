using Nancy;
using Nancy.Security;
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
                var model = new UserModel(Context.CurrentUser.UserName);
                return View["secure.cshtml", model];
            };
        }
    }
}