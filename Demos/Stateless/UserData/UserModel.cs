﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stateless.UserData
{
    public class UserModel
    {
        public string Username { get; private set; }

        public UserModel(string username)
        {
            Username = username;
        }
    }
}