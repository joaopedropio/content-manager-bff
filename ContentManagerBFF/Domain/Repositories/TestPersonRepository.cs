using ContentClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Domain.Repositories
{
    public class TestPersonRepository : IRepository<Person>
    {
        private List<Person> persons;

        public TestPersonRepository()
        {
            this.persons = PersonsSingleton.Instance;
        }
        public async Task<Person> FindById(uint id)
        {
            var index = int.Parse(id.ToString());
            return await Task.Run(() => this.persons[index]);
        }

        public async Task Insert(Person obj)
        {
            await Task.Run(() => this.persons.Add(obj));
        }

        public async Task<IList<Person>> List()
        {
            return await Task.Run(() => this.persons);
        }

        public async Task Remove(uint id)
        {
            var index = int.Parse(id.ToString());
            await Task.Run(() => this.persons.RemoveAt(index));
        }
    }
}
