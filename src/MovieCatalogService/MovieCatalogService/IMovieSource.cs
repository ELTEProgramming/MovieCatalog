//-----------------------------------------------------------------------
// <copyright file="imoviesource.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/9/2016 4:28 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalogService
{
    /// <summary>
    /// Represents a movie data source.
    /// </summary>
    public interface IMovieSource
    {
        /// <summary>
        /// Gets the movie specified by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The movie if it was found; <see cref="null"/> otherwise.</returns>
        Movie GetMovieById(string id);

        /// <summary>
        /// Gets the movies matches the title part specified.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="page">The page.</param>
        /// <returns>A <see cref="MovieSearchResult"/> object describes the result.</returns>
        MovieSearchResult GetMovies(string title, int page = 1);
    }
}
