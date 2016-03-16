using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogService.OmdbSource
{
    [Serializable]
    public class OmdbMovieSourceException : MovieSourceException, ISerializable
    {
        public OmdbMovieSourceException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }

        protected OmdbMovieSourceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
