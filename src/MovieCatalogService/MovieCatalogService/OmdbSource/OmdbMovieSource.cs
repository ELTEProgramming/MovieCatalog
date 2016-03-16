using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MovieCatalogService.OmdbSource
{
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

        public OmdbMovieSource(string baseUri = null)
        {
            this.baseUri = new Uri(baseUri ?? DefaultBaseUri);
        }

        public Movie GetMovieById(string id)
        {
            string json;

            if (!this.TryGetJson(this.baseUri.AppendQueryArgument(IdSearchQueryArgument, id), out json))
                return null; // todo: log

            OmdbMovie dto;

            try
            {
                dto = JsonConvert.DeserializeObject<OmdbMovie>(json);
            }
            catch (JsonException)
            {
                return null; // todo: log!
            }

            if (!dto.Response)
                return null; // todo: log, use the Error property!

            return mapper.Map<OmdbMovie, Movie>(dto);
        }

        public MovieSearchResult GetMovies(string title, int page = 1)
        {
            string json;

            if (!this.TryGetJson(this.baseUri
                .AppendQueryArgument(TitleSearchQueryArgument, title)
                .AppendQueryArgument(PageQueryArgument, page.ToString()), out json))
                return null; // todo: log

            OmdbMovieSearchResult dto;

            try
            {
                dto = JsonConvert.DeserializeObject<OmdbMovieSearchResult>(json);
            }
            catch (JsonException)
            {
                return null; // todo: log!
            }

            if (!dto.Response)
                return new MovieSearchResult
                {
                    Page = page,
                    Total = 0,
                    Movies = Enumerable.Empty<Movie>()
                }; // todo: log, use the Error property!

            var result = mapper.Map<OmdbMovieSearchResult, MovieSearchResult>(dto);
            result.Page = page;
            return result;
        }

        private bool TryGetJson(Uri uri, out string json)
        {
            json = null;

            if (uri == null)
                throw new ArgumentNullException("uri cannot be null");

            try
            {
                using (var response = (HttpWebResponse)HttpWebRequest.CreateHttp(uri).GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK || response.ContentLength == 0)
                        return false; // todo: handle!

                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                        json = reader.ReadToEnd();
                }
            }
            catch (WebException)
            {
                return false; // todo: log!
            }

            return true;
        }

        private class OmdbMapperProfile : Profile
        {
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
