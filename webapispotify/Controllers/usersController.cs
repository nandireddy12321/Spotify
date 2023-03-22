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
    public class usersController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(user))]
        [Route("api/users/{user}/{pwd}")]
        public IHttpActionResult Authenticate(String user, String pwd)
        {
            spotifyDao dao = new spotifyDao();
            int result = dao.usersauthentication(user, pwd);
            String res = "";
            res += result;
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(res, Encoding.UTF8, "application/json");
            return ResponseMessage(response);

        }
        [HttpPost]
        [Route("api/user/adduser/")]
        
        
        public IHttpActionResult Adduser(user user)
        {
            spotifyDao dao = new spotifyDao();
            string result = dao.createaccount(user);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(result, Encoding.UTF8, "application/json");
            return ResponseMessage(response);
        }
    }
}
