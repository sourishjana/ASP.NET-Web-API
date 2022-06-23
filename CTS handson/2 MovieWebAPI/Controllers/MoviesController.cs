using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieWebAPI.Controllers
{
    public class MoviesController : ApiController
    {

        public List<string> GetMovies()
        {
            return new List<string> {"Titanic","Mission Impossible","Matrix" };
        }
    }
}
