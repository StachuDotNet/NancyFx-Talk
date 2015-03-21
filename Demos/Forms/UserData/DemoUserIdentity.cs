using Nancy.Security;
using System.Collections.Generic;

namespace Forms.UserData
{
    public class DemoUserIdentity : IUserIdentity
    {
        public string UserName { get; set; }

        public IEnumerable<string> Claims { get; set; }
    }
}