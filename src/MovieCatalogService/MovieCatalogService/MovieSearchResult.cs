//-----------------------------------------------------------------------
// <copyright file="moviesearchresult.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/14/2016 2:18 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalogService
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents result data for a movie search.
    /// </summary>
    public class MovieSearchResult
    {
        /// <summary>
        /// Gets or sets the page requested.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the total movies available as result.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the movies on the given page of the result set.
        /// </summary>
        public IEnumerable<Movie> Movies { get; set; }
    }
}
