using System.Collections.Generic;
using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/movies")]
    public class MoviesV2Controller : Controller
    {
        private static List<MovieV2> _movies = new List<MovieV2>()
        {
            new MovieV2()
            {
                Id = 0,
                MovieDescription = "Action movie by Keanu Reeves",
                MovieName = "John Wick",
                Type = "Action"
            },
            new MovieV2()
            {
                Id = 1,
                MovieDescription = "Another one action movie by Keanu Reeves",
                MovieName = "John Wick 2",
                Type = "Action"
            }
        };

        // GET: api/MovieV2
        [HttpGet]
        public IEnumerable<MovieV2> Get()
        {
            return _movies;
        }

        // GET: api/MovieV2/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/MovieV2
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/MovieV2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
