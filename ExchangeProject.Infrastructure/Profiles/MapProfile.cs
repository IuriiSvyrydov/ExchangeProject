using ExchangeProject.Core.Models;
using ExchangeProject.Infrastructure.DTOs;
using ExchangeProject.Infrastructure.Models;

namespace ExchangeProject.Infrastructure.Profiles
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<CurrencyDto, Currency>().ReverseMap();
            CreateMap<ExchangeDto, Exchange>().ReverseMap();
            CreateMap<CurrencyModel, Currency>().ReverseMap();
        }
    }
}
