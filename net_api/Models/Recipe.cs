using System;
using System.Collections.Generic;

namespace net_api.Models
{
    public record Recipe
    {
        public string Title { get; set; }

        public string Description { get; set; } = string.Empty;

        public IEnumerable<string> Directions { get; set; }

        public IEnumerable<string> Ingredients { get; set; }

        public DateTime Updated { get; set; }

    }
}
