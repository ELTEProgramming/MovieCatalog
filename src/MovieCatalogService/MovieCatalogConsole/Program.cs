using MovieCatalogService;
using MovieCatalogService.OmdbSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var term = "supergirl";
            var source = new OmdbMovieSource();
            MovieSearchResult movies;

            for (movies = source.GetMovies(term, 1); movies.Movies.Any(); movies = source.GetMovies(term, movies.Page + 1))
                foreach (var movie in movies.Movies)
                    Console.WriteLine("{0}: {1}", movie.Id, movie.Title);

            Console.ReadKey(true);
        }
    }
}
