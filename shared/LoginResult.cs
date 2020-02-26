using System;
using System.Collections.Generic;
using System.Text;

namespace shared
{
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
