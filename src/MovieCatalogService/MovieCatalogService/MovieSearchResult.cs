using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogService
{
    public class MovieSearchResult
    {
        public int Page { get; set; }
        public int Total { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
