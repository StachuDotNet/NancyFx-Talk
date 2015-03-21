using Nancy.Security;
using System.Collections.Generic;

namespace Stateless.UserData
{
    public class DemoUserIdentity : IUserIdentity
    {
        public string UserName { get; set; }

        public IEnumerable<string> Claims { get; set; }
    }
}