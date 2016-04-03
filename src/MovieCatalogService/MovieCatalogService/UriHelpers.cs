//-----------------------------------------------------------------------
// <copyright file="urihelpers.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/9/2016 5:18 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalogService
{
    using System;
    using System.Web;

    /// <summary>
    /// Provides fluent api functionality for operations on <see cref="System.Uri"/> objects.
    /// </summary>
    public static class UriHelpers
    {
        /// <summary>
        /// Appends the specified query argument to the given uri.
        /// </summary>
        /// <param name="baseUri">The uri.</param>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        /// <returns>The result uri.</returns>
        public static Uri AppendQueryArgument(this Uri baseUri, string name, string value)
        {
            var uriBuilder = new UriBuilder(baseUri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[name] = value;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}
