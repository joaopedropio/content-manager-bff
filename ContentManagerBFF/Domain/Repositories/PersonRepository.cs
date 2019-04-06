using System.Collections.Generic;
using System.Threading.Tasks;
using ContentClient.Models;

namespace ContentManagerBFF.Domain.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private ContentClient.ContentClient contentClient;

        public PersonRepository()
        {
            var contentApiUrl = new Configuration().ContentAPIURL;
            this.contentClient = new ContentClient.ContentClient(contentApiUrl);
        }

        public async Task<Person> FindById(uint id)
        {
            return await this.contentClient.Get<Person>(id);
        }

        public async Task Insert(Person person)
        {
            await this.contentClient.Insert(person);
        }

        public async Task<IList<Person>> List()
        {
            return await this.contentClient.Get<Person>();
        }

        public async Task Remove(uint id)
        {
            await this.contentClient.Delete<Person>(id);
        }
    }
}
