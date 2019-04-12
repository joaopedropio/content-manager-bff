using ContentClient.Models;
using ContentManagerBFF.Domain.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContentManagerBFF.Controllers
{
    [Produces("application/json")]
    public class PersonController : Controller
    {
        public IRepository<Person> Persons { get; }

        public PersonController(IRepository<Person> persons)
        {
            this.Persons = persons;
        }
        
        [Route("/api/person")]
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await this.Persons.List();
        }
        
        [Route("/api/person/{*personId}")]
        [HttpGet]
        public async Task<Person> Get(uint personId)
        {
            return await this.Persons.FindById(personId);
        }
        
        [Route("/api/person")]
        [HttpPost]
        public async Task<IEnumerable<Person>> Post([FromBody] Person personModel)
        {
            await this.Persons.Insert(personModel);
            return await this.Persons.List();
        }
        
        [Route("/api/person/{*personId}")]
        [HttpDelete]
        public async Task<IEnumerable<Person>> Delete(uint personId)
        {
            await this.Persons.Remove(personId);
            return await this.Persons.List();
        }
    }
}
