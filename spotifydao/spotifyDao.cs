using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using spotifyentities;

namespace spotifydao
{
    public class spotifyDao
    {
        SqlConnection conn;
        SqlDataAdapter ad;

        public List<artists> showartist()
        {
            conn = ConnectionHelper.GetConnection();
            ad = new SqlDataAdapter("select * from artists", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "ArtistDummy");
            List<artists> list = new List<artists>();
            artists artist = null;
            foreach (DataRow dr in ds.Tables["ArtistDummy"].Rows)
            {
                artist = new artists();
                artist.name = dr["name"].ToString();
                artist.dateofbirth = Convert.ToDateTime(dr["dateofbirth"].ToString());
                artist.bio=dr["bio"].ToString();
                //artist.Images = byte[(dr["Images"].ToString()];
                list.Add(artist);
            }
            return list;
        }

        public string Addartist(artists artists)
        {
            conn = ConnectionHelper.GetConnection();
            SqlCommand cmd = new SqlCommand("spaddartist", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", artists.name);

            byte[] image = (byte[])
                cmd.ExecuteScalar();
           cmd.Parameters.AddWithValue("@image",  image.Length);
            cmd.Parameters.AddWithValue("@dateofbirth",artists.dateofbirth);
            cmd.Parameters.AddWithValue("bio", artists.bio);
            cmd.ExecuteNonQuery();


            return "added successfully";
        }
        public List<songs> showsongs()
        {
            conn = ConnectionHelper.GetConnection();
            ad = new SqlDataAdapter("select * from songs", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "SongDummy");
            List<songs> list = new List<songs>();
           songs song = null;
            foreach (DataRow dr in ds.Tables["SongDummy"].Rows)
            {
               song = new songs();
               song.songname = dr["songname"].ToString();
               song.dateofrelease = Convert.ToDateTime(dr["dateofrelease"].ToString());
                
                list.Add(song);
            }
            return list;
        }
        public string Addsong(songs songs)
        {
            conn = ConnectionHelper.GetConnection();
            SqlCommand cmd = new SqlCommand("spaddsong", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@songname", songs.songname);
            cmd.Parameters.AddWithValue("@dateofrelease", songs.dateofrelease);
            
            cmd.ExecuteNonQuery();


            return "added successfully";
        }

        public int usersauthentication(string email, string password)
        {
            conn = ConnectionHelper.GetConnection();
            ad = new SqlDataAdapter("select count(*) cnt from users where email=@email AND " +
                "password=@password", conn);
            ad.SelectCommand.Parameters.AddWithValue("@email", email);
            ad.SelectCommand.Parameters.AddWithValue("@password", password);
            DataSet ds = new DataSet();
            ad.Fill(ds, "UserauthDummy");
            int count = Convert.ToInt32(ds.Tables["UserauthDummy"].Rows[0]["cnt"]);
            if (count == 1)
            {
                Console.WriteLine("Correct Credentials...");
            }
            else
            {
                Console.WriteLine("Invalid Credentials...");
            }
            return count;
        }
        public string createaccount(user user)
        {
            conn = ConnectionHelper.GetConnection();
            SqlCommand cmd = new SqlCommand("spcreateusers", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.ExecuteNonQuery();


            return "added successfully";
        }

    }
}
