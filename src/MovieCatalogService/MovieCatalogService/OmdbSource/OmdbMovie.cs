using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogService.OmdbSource
{
    public class OmdbMovie : OmdbMessage
    {
        public string Title { get; set; }
        public string ImdbId { get; set; }
    }
}
