﻿using System.Collections.Generic;

namespace ContentManagerBFF.Domain.Models
{
    public class Movie : Content
    {
        public string Synopsis { get; set; }

        public string ShortDescription { get; set; }

        public ulong Duration { get; set; }

        public ulong Budget { get; set; }

        public Media Video { get; set; }

        public IList<Professional> Professionals { get; set; }
    }
}
