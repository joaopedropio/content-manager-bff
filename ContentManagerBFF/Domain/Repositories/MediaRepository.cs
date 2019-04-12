using ContentClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Domain.Repositories
{
    public class MediaRepository : IRepository<Media>
    {
        private ContentClient.ContentClient contentClient;

        public MediaRepository()
        {
            var contentApiUrl = new Configuration().ContentAPIURL;
            this.contentClient = new ContentClient.ContentClient(contentApiUrl);
        }

        public async Task<Media> FindById(uint id)
        {
            return await this.contentClient.Get<Media>(id);
        }

        public async Task Insert(Media obj)
        {
            await this.contentClient.Insert(obj);
        }

        public async Task<IList<Media>> List()
        {
            return await this.contentClient.Get<Media>();
        }

        public async Task Remove(uint id)
        {
            await this.contentClient.Delete<Media>(id);
        }
    }
}
