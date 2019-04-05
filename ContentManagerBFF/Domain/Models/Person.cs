using System;

namespace ContentManagerBFF.Domain.Models
{
    public class Person
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
    }
}
