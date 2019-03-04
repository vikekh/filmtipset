using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Vikekh.Filmtipset.Core.Interfaces;
using Vikekh.Filmtipset.Core.Models;

namespace Vikekh.Filmtipset.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;
        private readonly Settings _settings;

        public MovieService(HttpClient client, IMapper mapper, IOptions<Settings> settings)
        {
            _client = client;
            _mapper = mapper;
            _settings = settings.Value;
            _baseUrl = $"http://www.filmtipset.se/api/api.cgi?accesskey={_settings.FilmtipsetApiAccessKey}&userkey={_settings.FilmtipsetApiUserKey}&returntype=json";
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            var json = await _client.GetStringAsync($"{_baseUrl}&action=movie&id={id}");
            var jArray = JArray.Parse(json);
            var jObject = (JObject)jArray[0]["data"][0]["movie"];
            return _mapper.Map<Movie>(jObject);
        }
    }
}
