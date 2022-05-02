﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CendynUIKit.Models
{
    public interface ILogin
    {
        void Login(string username, string password);
        void SetUsername(string username);
        void SetPassword(string password);
        void BeginSignIn();
    }
}
