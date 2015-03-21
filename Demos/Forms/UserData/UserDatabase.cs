using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forms.UserData
{
    public class UserDatabase : IUserMapper
    {
        private static readonly List<Tuple<string, string, Guid>> Users = new List<Tuple<string, string, Guid>>();

        static UserDatabase()
        {
            Users.Add(new Tuple<string, string, Guid>("admin", "password", new Guid("55E1E49E-B7E8-4EEA-8459-7A906AC4D4C0")));
            Users.Add(new Tuple<string, string, Guid>("user", "password", new Guid("56E1E49E-B7E8-4EEA-8459-7A906AC4D4C0")));
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var userRecord = Users.FirstOrDefault(u => u.Item3 == identifier);

            return userRecord == null
                ? null
                : new DemoUserIdentity { UserName = userRecord.Item1 };
        }

        public static Guid? ValidateUser(string username, string password)
        {
	        var userRecord = Users.FirstOrDefault(u => u.Item1 == username && u.Item2 == password);

	        return userRecord == null 
				? (Guid?) null 
				: userRecord.Item3;
        }
    }
}