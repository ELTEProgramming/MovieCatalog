using MovieCatalogService;
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
            var source = new OmdbMovieSource();
            var movie = source.GetMovieById("tt0371746");

            Console.WriteLine("{0}: {1}", movie.Id, movie.Title);
            Console.ReadKey(true);
        }
    }
}
