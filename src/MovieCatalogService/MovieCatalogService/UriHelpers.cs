using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MovieCatalogService
{
    public static class UriHelpers
    {
        public static Uri AppendQueryArgument(this Uri baseUri, string name, string value)
        {
            var uriBuilder = new UriBuilder(baseUri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[name] = value;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}
