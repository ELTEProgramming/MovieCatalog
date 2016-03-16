using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogService
{
    public interface IMovieSource
    {
        /// <summary>
        /// Gets the movie specified by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The movie if it was found; <see cref="null"/> otherwise.</returns>
        Movie GetMovieById(string id);

        MovieSearchResult GetMovies(string title, int page = 1); // todo: comment
    }
}
