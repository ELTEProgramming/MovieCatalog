using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogService
{
    public interface IMovieSource
    {
        Movie GetMovieById(string id);
    }
}
