using AutoMapper;
using KamikazeVTPRO.Model.Models;
using KamikazeVTPRO.Web.Models;

namespace KamikazeVTPRO.Web.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappers()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
        }
    }
}