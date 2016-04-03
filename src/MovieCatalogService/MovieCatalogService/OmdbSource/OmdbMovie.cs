//-----------------------------------------------------------------------
// <copyright file="omdbmovie.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/16/2016 12:50 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalogService.OmdbSource
{
    /// <summary>
    /// Represents an OMDB movie.
    /// </summary>
    /// <seealso cref="MovieCatalogService.OmdbSource.OmdbMessage" />
    public class OmdbMovie : OmdbMessage
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the imdb identifier associated to this movie.
        /// </summary>
        public string ImdbId { get; set; }
    }
}
