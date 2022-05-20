using AutoMapper;
using Entity.Models;
using WebAPI.Model.Dto.Payment;

namespace WebAPI.Model.AutoMapperProfiles
{
    public class SubscriptionsProfile: Profile
    {
        public SubscriptionsProfile()
        {
            CreateMap<Subscriptionn, SubscriptionDto>();
            CreateMap<SubscriptionCreateDto, Subscriptionn>();
        }
    }
}
