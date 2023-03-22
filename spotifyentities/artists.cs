using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifyentities
{
    public class artists
    {
     public string name { get; set; }
        public DateTime dateofbirth;
        public string bio { get; set; }
        public Byte Images { get; set; }

        public override string ToString()
        {
            return "name" + name + "bio" + bio + Images +"Images";
        }

    }
}
