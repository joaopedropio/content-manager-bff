using ContentClient.Models;
using ContentManagerBFF.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Controllers
{
    [Produces("application/json")]
    [Route("/api/movie")]
    public class MoviesController : Controller
    {
        public IRepository<Movie> Movies { get; }

        public MoviesController(IRepository<Movie> movies)
        {
            this.Movies = movies;
        }

        [Route("/api/media")]
        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {
            return await this.Movies.List();
        }

        [Route("/api/movie/{*movieId}")]
        [HttpGet]
        public async Task<Movie> Get(uint movieId)
        {
            return await this.Movies.FindById(movieId);
        }

        [Route("/api/movie")]
        [HttpPost]
        public async Task<IEnumerable<Movie>> Post([FromBody] Movie movieModel)
        {
            await this.Movies.Insert(movieModel);
            return await this.Movies.List();
        }

        [Route("/api/movie/{*movieId}")]
        [HttpDelete]
        public async Task<IEnumerable<Movie>> Delete(uint movieId)
        {
            await this.Movies.Remove(movieId);
            return await this.Movies.List();
        }
    }
}