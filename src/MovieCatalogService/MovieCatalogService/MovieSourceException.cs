using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogService
{
    [Serializable]
    public abstract class MovieSourceException : Exception, ISerializable
    {
        public MovieSourceException(string message = null, Exception innerException = null)
            : base(message ?? Resources.MovieSourceExceptionDefaultMessage, innerException)
        {
        }

        protected MovieSourceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
