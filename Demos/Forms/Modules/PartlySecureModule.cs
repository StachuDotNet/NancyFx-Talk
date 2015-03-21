using Nancy;
using Nancy.Security;
using Forms.UserData;

namespace Forms.Modules
{
    public class PartlySecureModule : NancyModule
    {
        public PartlySecureModule()
            : base("/partlysecure")
        {
            Get["/"] = _ => "No auth needed! <a href='partlysecure/secured'>Enter the secure bit!</a>";

            Get["/secured"] = x =>
            {
                this.RequiresAuthentication();

                var model = new UserModel(Context.CurrentUser.UserName);
                return View["secure.cshtml", model];
            };
        }
    }
}