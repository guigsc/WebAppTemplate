using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppTemplate.Model.Auth
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Expires { get; set; }
    }
}
