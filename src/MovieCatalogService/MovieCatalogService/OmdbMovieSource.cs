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

namespace MovieCatalogService
{
    public class OmdbMovieSource : IMovieSource
    {
        private readonly IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<OmdbMapperProfile>()).CreateMapper();

        public Movie GetMovieById(string id)
        {
            var uri = new Uri("http://www.omdbapi.com/").AppendQueryArgument(new KeyValuePair<string, string>("i", id));

            var json = this.GetJson(uri);

            OmdbMovie dto;

            try
            {
                dto = JsonConvert.DeserializeObject<OmdbMovie>(json);
            }
            catch (JsonException)
            {
                return null; // todo: log!
            }

            return mapper.Map<OmdbMovie, Movie>(dto);
        }

        private string GetJson(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri cannot be null");

            try
            {
                using (var response = (HttpWebResponse)HttpWebRequest.CreateHttp(uri).GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK || response.ContentLength == 0)
                        return null; // todo: handle!

                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                        return reader.ReadToEnd();
                }
            }
            catch (WebException)
            {
                return null; // todo: log!
            }
        }

        private class OmdbMapperProfile : Profile
        {
            protected override void Configure()
            {
                this.CreateMap<OmdbMovie, Movie>().ForMember(movie => movie.Id, memberConfiguration => memberConfiguration.MapFrom(dto => dto.ImdbId));
            }
        }
    }
}
