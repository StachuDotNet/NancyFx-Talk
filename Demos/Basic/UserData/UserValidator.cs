using Nancy.Authentication.Basic;
using Nancy.Security;

namespace Basic.UserData
{
    public class UserValidator : IUserValidator
    {
        public IUserIdentity Validate(string username, string password)
        {
            if (username == "demo" && password == "demo")
                return new DemoUserIdentity { UserName = username };

            // Not recognised => anonymous.
            return null;
        }
    }
}