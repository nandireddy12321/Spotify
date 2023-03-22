using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using spotifydao;
using spotifyentities;
using System.Web.Http.Description;


namespace webapispotify.Controllers
{
    public class songsController : ApiController
    {
        public IQueryable<songs> Getsongs()
        {
            spotifyDao dao = new spotifyDao();
            List<songs> song = dao.showsongs();
            IQueryable<songs> response = song.AsQueryable();
            return response;
        }
        [HttpPost]
        [Route("api/song/addsong/")]
        public IHttpActionResult Addsong(songs songs)
        {
            spotifyDao dao = new spotifyDao();
            string result = dao.Addsong(songs);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(result, Encoding.UTF8, "application/json");
            return ResponseMessage(response);
        }

    }
}
