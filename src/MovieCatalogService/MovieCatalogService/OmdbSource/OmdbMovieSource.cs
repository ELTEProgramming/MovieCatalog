//-----------------------------------------------------------------------
// <copyright file="omdbmoviesource.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/16/2016 12:50 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalogService.OmdbSource
{
    using AutoMapper;
    using Newtonsoft.Json;
    using NLog;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;

    /// <summary>
    /// Represents an OMDB movie source.
    /// </summary>
    /// <remarks>For additional information, see www.omdbapi.com.</remarks>
    /// <seealso cref="MovieCatalogService.IMovieSource" />
    public class OmdbMovieSource : IMovieSource
    {
        private const string
            DefaultBaseUri = "http://www.omdbapi.com/",
            IdSearchQueryArgument = "i",
            TitleSearchQueryArgument = "s",
            PageQueryArgument = "page";

        private static readonly MapperConfiguration MapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<OmdbMapperProfile>());
        private readonly IMapper mapper = MapperConfiguration.CreateMapper();
        private readonly Uri baseUri;
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="OmdbMovieSource"/> class.
        /// </summary>
        /// <param name="baseUri">The base uri for the OMDB api.</param>
        public OmdbMovieSource(string baseUri = null)
        {
            this.baseUri = new Uri(baseUri ?? DefaultBaseUri);
        }

        /// <summary>
        /// Gets the movie specified by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The movie if it was found; <see cref="null" /> otherwise.
        /// </returns>
        /// <exception cref="MovieCatalogService.OmdbSource.OmdbMovieSourceException">
        /// Failed to retrieve movie information.
        /// </exception>
        public Movie GetMovieById(string id)
        {
            var uri = this.baseUri.AppendQueryArgument(IdSearchQueryArgument, id);
            string json;

            try
            {
                json = this.GetContent(uri);
            }
            catch (WebException ex)
            {
                this.logger.Error(string.Format(Resources.OmdbNetworkError, uri), ex);
                throw new OmdbMovieSourceException(innerException: ex);
            }

            if (string.IsNullOrWhiteSpace(json))
            {
                this.logger.Error(string.Format(Resources.OmdbDataError, uri));
                throw new OmdbMovieSourceException(string.Format(Resources.OmdbDataError, uri));
            }

            OmdbMovie dto;

            try
            {
                dto = JsonConvert.DeserializeObject<OmdbMovie>(json);
            }
            catch (JsonException ex)
            {
                this.logger.Error(string.Format(Resources.OmdbDataError, uri), ex);
                throw new OmdbMovieSourceException(string.Format(Resources.OmdbDataError, uri), ex);
            }

            if (!dto.Response)
                return null;

            return this.mapper.Map<OmdbMovie, Movie>(dto);
        }

        /// <summary>
        /// Gets the movies matches the title part specified.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="page">The page.</param>
        /// <returns>
        /// A <see cref="MovieSearchResult" /> object describes the result.
        /// </returns>
        /// <exception cref="MovieCatalogService.OmdbSource.OmdbMovieSourceException">
        /// Failed to retrieve movie information.
        /// </exception>
        public MovieSearchResult GetMovies(string title, int page = 1)
        {
            var uri = this.baseUri
                .AppendQueryArgument(TitleSearchQueryArgument, title)
                .AppendQueryArgument(PageQueryArgument, page.ToString());
            string json;

            try
            {
                json = this.GetContent(uri);
            }
            catch (WebException ex)
            {
                this.logger.Error(string.Format(Resources.OmdbNetworkError, uri), ex);
                throw new OmdbMovieSourceException(innerException: ex);
            }

            if (string.IsNullOrWhiteSpace(json))
            {
                this.logger.Error(string.Format(Resources.OmdbDataError, uri));
                throw new OmdbMovieSourceException(string.Format(Resources.OmdbDataError, uri));
            }

            OmdbMovieSearchResult dto;

            try
            {
                dto = JsonConvert.DeserializeObject<OmdbMovieSearchResult>(json);
            }
            catch (JsonException ex)
            {
                this.logger.Error(string.Format(Resources.OmdbDataError, uri), ex);
                throw new OmdbMovieSourceException(string.Format(Resources.OmdbDataError, uri), ex);
            }

            if (!dto.Response)
                return new MovieSearchResult
                {
                    Page = page,
                    Total = 0, // todo: not necessary 0 if page > 1
                    Movies = Enumerable.Empty<Movie>()
                };

            var result = this.mapper.Map<OmdbMovieSearchResult, MovieSearchResult>(dto);
            result.Page = page;
            return result;
        }

        private string GetContent(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri cannot be null");

            using (var response = (HttpWebResponse)HttpWebRequest.CreateHttp(uri).GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK || response.ContentLength == 0)
                    return null;

                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                    return reader.ReadToEnd();
            }
        }

        private class OmdbMapperProfile : Profile
        {
            /// <summary>
            /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
            /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
            /// </summary>
            protected override void Configure()
            {
                this.CreateMap<OmdbMovie, Movie>().ForMember(movie => movie.Id, memberConfiguration => memberConfiguration.MapFrom(dto => dto.ImdbId));
                this.CreateMap<OmdbMovieSearchResult, MovieSearchResult>()
                    .ForMember(result => result.Movies, memberConfiguration => memberConfiguration.MapFrom(dto => dto.Search))
                    .ForMember(result => result.Total, memberConfiguration => memberConfiguration.MapFrom(dto => dto.TotalResults));
            }
        }
    }
}
