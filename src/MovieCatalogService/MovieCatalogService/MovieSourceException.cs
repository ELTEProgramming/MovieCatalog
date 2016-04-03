//-----------------------------------------------------------------------
// <copyright file="moviesourceexception.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/16/2016 12:50 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalogService
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents the abstract base class for movie source related exceptions.
    /// </summary>
    /// <seealso cref="System.Exception" />
    /// <seealso cref="System.Runtime.Serialization.ISerializable" />
    [Serializable]
    public abstract class MovieSourceException : Exception, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieSourceException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public MovieSourceException(string message = null, Exception innerException = null)
            : base(message ?? Resources.MovieSourceExceptionDefaultMessage, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieSourceException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected MovieSourceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
