using ContentClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Domain.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private ContentClient.ContentClient contentClient;

        public MovieRepository()
        {
            var contentApiUrl = new Configuration().ContentAPIURL;
            this.contentClient = new ContentClient.ContentClient(contentApiUrl);
        }

        public async Task<Movie> FindById(uint id)
        {
            return await this.contentClient.Get<Movie>(id);
        }

        public async Task Insert(Movie obj)
        {
            await this.contentClient.Insert(obj);
        }

        public async Task<IList<Movie>> List()
        {
            return await this.contentClient.Get<Movie>();
        }

        public async Task Remove(uint id)
        {
            await this.contentClient.Delete<Movie>(id);
        }
    }
}
