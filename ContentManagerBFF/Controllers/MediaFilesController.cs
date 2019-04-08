using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Controllers
{
    public class MediaFilesController : Controller
    {
        private ContentClient.ContentClient client;

        public MediaFilesController()
        {
            var contentApiUrl = new Configuration().ContentAPIURL;
            this.client = new ContentClient.ContentClient(contentApiUrl);
        }

        [Route("/mediafiles")]
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await this.client.GetMediaFilesPaths();
        }
    }
}
