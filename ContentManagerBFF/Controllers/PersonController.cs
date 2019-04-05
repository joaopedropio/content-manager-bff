using ContentManagerBFF.Domain.Models;
using ContentManagerBFF.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Controllers
{
    public class PersonController : Controller
    {
        public IRepository<Person> Persons { get; }

        public PersonController(IRepository<Person> persons)
        {
            this.Persons = persons;
        }

        [Route("/api/person")]
        [HttpPost]
        public async Task<IEnumerable<Person>> Post([FromBody] Person personModel)
        {
            var persons = await this.Persons.List();
            personModel.Id = uint.Parse(persons.Count.ToString());
            await this.Persons.Insert(personModel);
            return await this.Persons.List();
        }

        [HttpDelete]
        public async Task<IEnumerable<Person>> Delete(uint personId)
        {
            await this.Persons.Remove(personId);
            return await this.Persons.List();
        }
    }
}
