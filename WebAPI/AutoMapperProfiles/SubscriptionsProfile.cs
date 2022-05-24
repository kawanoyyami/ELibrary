using AutoMapper;
using Common.Dto.Payment;
using Domain.Models.Subscriptio;

namespace BL.AutoMapperProfiles
{
    public class SubscriptionsProfile : Profile
    {
        public SubscriptionsProfile()
        {
            CreateMap<Subscriptionn, SubscriptionDto>();
            CreateMap<SubscriptionCreateDto, Subscriptionn>();
        }
    }
}
