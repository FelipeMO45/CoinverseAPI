using AutoMapper;
using CoinverseSocialAPI.DTO;
using CoinverseSocialAPI.Models;

namespace CoinverseSocialAPI.Infrastructure.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();

            // CreateMap<UserModel, UserCreateDto>();
            // CreateMap<UserCreateDto, UserModel>();
            CreateMap<UserModel, UserMinUpdateDTO>();
            CreateMap<UserMinUpdateDTO, UserModel>();
        }
    }
}
