using ContentManagerBFF.Domain.Models;
using System.Collections.Generic;

namespace ContentManagerBFF.Domain.Repositories
{
    public sealed class PersonsSingleton
    {
        private static readonly List<Person> instance = new List<Person>();

        public static List<Person> Instance => instance;
    }
}