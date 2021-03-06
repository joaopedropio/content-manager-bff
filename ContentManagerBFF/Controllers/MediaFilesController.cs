﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Controllers
{
    [Produces("application/json")]
    public class MediaFilesController : Controller
    {
        private ContentClient.ContentClient client;

        public MediaFilesController()
        {
            var contentApiUrl = new Configuration().ContentAPIURL;
            this.client = new ContentClient.ContentClient(contentApiUrl);
        }

        [Route("/api/mediafiles")]
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var x = await this.client.GetMediaFilesPaths();
            if (x == null || x?.Count == 0)
                return new List<string>();

            return x;
        }
    }
}
