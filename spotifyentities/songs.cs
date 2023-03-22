using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotifyentities
{
    public class songs
    {
        public string songname { get; set; }
        public DateTime dateofrelease;
        public override string ToString()
        {
            return "songname"+ songname + "dateofrelease" + dateofrelease;
        }

    }
}
