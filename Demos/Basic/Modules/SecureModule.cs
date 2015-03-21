using Nancy;
using Nancy.Security;

namespace Basic.Modules
{
    public class SecureModule : NancyModule
    {
        public SecureModule()
            : base("/secure")
        {
            this.RequiresAuthentication();

            Get["/"] = x => "You're secure! Your name is: " + Context.CurrentUser.UserName;
        }
    }
}