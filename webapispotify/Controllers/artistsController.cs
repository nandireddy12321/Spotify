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
    public class artistsController : ApiController
    {
        public IQueryable<artists> Getartists()
        {
            spotifyDao dao = new spotifyDao();

            List<artists> List = dao.showartist();
            IQueryable<artists> art = List.AsQueryable();
            return art;
        }


        [HttpPost]
        [Route("api/artists/addartist/")]
        public IHttpActionResult Addartist(artists artists)
        {
            spotifyDao dao = new spotifyDao();
            string result = dao.Addartist(artists);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(result, Encoding.UTF8, "application/json");
            return ResponseMessage(response);
        }
    }
}
