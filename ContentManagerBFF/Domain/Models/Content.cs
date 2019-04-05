using System;

namespace ContentManagerBFF.Domain.Models
{
    public class Content
    {
        public uint? Id { get; set; }

        public string Name { get; set; }

        public Media CoverImage { get; set; }

        public string Country { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Studio { get; set; }
    }
}
