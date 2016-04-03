//-----------------------------------------------------------------------
// <copyright file="omdbmoviesearchresult.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/16/2016 12:50 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalogService.OmdbSource
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an OMDB search result.
    /// </summary>
    /// <seealso cref="MovieCatalogService.OmdbSource.OmdbMessage" />
    public class OmdbMovieSearchResult : OmdbMessage
    {
        /// <summary>
        /// Gets or sets the movies resulted in the search.
        /// </summary>
        public IEnumerable<OmdbMovie> Search { get; set; }

        /// <summary>
        /// Gets or sets the total number of results.
        /// </summary>
        public int TotalResults { get; set; }
    }
}
