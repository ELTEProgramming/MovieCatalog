using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogService.OmdbSource
{
    public class OmdbMovieSearchResult : OmdbMessage
    {
        public IEnumerable<OmdbMovie> Search { get; set; }
        public int TotalResults { get; set; }
    }
}
