using ContentClient.Models;
using ContentManagerBFF.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Controllers
{
    [Produces("application/json")]
    public class MediaController : Controller
    {
        public IRepository<Media> Medias { get; }

        public MediaController(IRepository<Media> medias)
        {
            this.Medias = medias;
        }

        [Route("/api/media")]
        [HttpGet]
        public async Task<IEnumerable<Media>> Get()
        {
            return await this.Medias.List();
        }

        [Route("/api/media/{*mediaId}")]
        [HttpGet]
        public async Task<Media> Get(uint mediaId)
        {
            return await this.Medias.FindById(mediaId);
        }

        [Route("/api/media")]
        [HttpPost]
        public async Task<IEnumerable<Media>> Post([FromBody] Media mediaModel)
        {
            await this.Medias.Insert(mediaModel);
            return await this.Medias.List();
        }

        [Route("/api/media/{*mediaId}")]
        [HttpDelete]
        public async Task<IEnumerable<Media>> Delete(uint mediaId)
        {
            await this.Medias.Remove(mediaId);
            return await this.Medias.List();
        }
    }
}
