using AutoMapper;
using Portfolio.API.Data.Entities;
using Portfolio.API.Dto.User;

namespace Portfolio.API.Services.Maps
{
    internal class UserMap : Profile
    {
        public UserMap() 
        {
            // Incoming
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();

            // Outgoing
            CreateMap<User, UserDto>();            
        }
    }
}
