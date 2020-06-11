using System;

namespace WebAppTemplate.Model.Auth
{
    public class SignInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Grant_Type { get; set; }
    }
}
