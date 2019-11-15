using AutoMapper;
using DataLayer.Entities;

namespace ServiceLayer.Implementation.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ViewModel.User.Create, User>();
            CreateMap<User, ViewModel.User.Full>();
            CreateMap<User, ViewModel.User.List>();
        }
    }
}
