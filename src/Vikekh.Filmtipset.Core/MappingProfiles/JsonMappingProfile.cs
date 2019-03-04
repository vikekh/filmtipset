using AutoMapper;
using Newtonsoft.Json.Linq;
using Vikekh.Filmtipset.Core.Models;

namespace Vikekh.Filmtipset.Core.MappingProfiles
{
    public class JsonMappingProfile : Profile
    {
        public JsonMappingProfile()
        {
            CreateMap<Movie, JObject>()
                .ForMember("id", options => options.MapFrom(v => v.Id));
                //.ForMember(dest => dest.Title, options => options.MapFrom("name"));
        }
    }
}
