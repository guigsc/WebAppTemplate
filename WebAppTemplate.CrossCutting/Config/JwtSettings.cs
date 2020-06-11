using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppTemplate.CrossCutting.Config
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Expires { get; set; }
    }
}
