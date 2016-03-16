using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogService.OmdbSource
{
    public class OmdbMessage
    {
        public OmdbMessage()
        {
            this.Response = true;
        }

        public bool Response { get; set; }
        public string Error { get; set; }
    }
}
