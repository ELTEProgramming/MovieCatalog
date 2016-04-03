//-----------------------------------------------------------------------
// <copyright file="omdbmessage.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/16/2016 12:50 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalogService.OmdbSource
{
    /// <summary>
    /// Represents the base message format for OMDB messages.
    /// </summary>
    public abstract class OmdbMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OmdbMessage"/> class.
        /// </summary>
        public OmdbMessage()
        {
            this.Response = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OmdbMessage"/> has a response part.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this message has a response part; otherwise, <c>false</c>.
        /// </value>
        public bool Response { get; set; }

        /// <summary>
        /// Gets or sets the error message provided in this message.
        /// </summary>
        public string Error { get; set; }
    }
}
