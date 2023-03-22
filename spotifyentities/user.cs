using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifyentities
{
    public class user
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }    
        public override string ToString()
        {
            return "name" +   name + "email" +   email+ "password"+   password;
        }
    }
}

