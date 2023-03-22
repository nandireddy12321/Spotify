using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using spotifydao;
using spotifyentities;


namespace mainspotify
{
    public class Program
    {

        public static void showartist()
        {

            spotifyDao dao = new spotifyDao();
            List<artists> list = dao.showartist( );
            foreach(artists at in list)
            {
                Console.WriteLine(at);
            }
        }


        public static void addartist()
        {
            artists artists = new artists( );
            Console.WriteLine("enter name  ");
            artists.name=Console.ReadLine( );
            Console.WriteLine("enter image path" );
            artists.Images = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("enter date of birth  ");
            artists.dateofbirth =Convert.ToDateTime( Console.ReadLine());
            Console.WriteLine("enter bio ");

            artists.bio = Console.ReadLine( );
            spotifyDao dao = new spotifyDao();
            Console.WriteLine(dao.Addartist(artists));
        }


        public static void showsongs()
        {

            spotifyDao dao = new spotifyDao();
            List<songs> list = dao.showsongs();
            foreach (songs sg in list)
            {
                Console.WriteLine(sg);
            }
        }


        public static void addsong()
        {
           songs song = new songs();
            Console.WriteLine("enter songname  ");
            song.songname = Console.ReadLine();
            Console.WriteLine("enter date of release  ");
            song.dateofrelease = Convert.ToDateTime(Console.ReadLine());
            
            spotifyDao dao = new spotifyDao();
            Console.WriteLine(dao.Addsong(song));
        }


        public static void usersauthentication()
        {
            string email =Console.ReadLine();
            Console.WriteLine("Enter email");
            string password =Console.ReadLine();
            Console.WriteLine("Enter password");
            spotifyDao dao = new spotifyDao();
            dao.usersauthentication(email , password);    
        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("O P T I O N S");
                Console.WriteLine("--------------");
                Console.WriteLine("1 Show artists");
                Console.WriteLine("2  add arist");
                Console.WriteLine("3  show songs");
                Console.WriteLine("4  sdd song");
                Console.WriteLine("5   authentication");
                Console.WriteLine("Enter Your Choice  ");
                choice = Convert.ToInt32(Console.ReadLine());




                switch (choice)
                {
                    case 1:
                        showartist();
                        break;
                    case 2:
                        addartist();
                        break;
                    case 3:
                       showsongs();
                        break;
                    case 4:
                        addsong();
                        break;
                    case 5:
                        usersauthentication();
                        break;
                    case 6:
                        return;
                }

                }
                while (choice != 5) ;
            
            }
    }
}
