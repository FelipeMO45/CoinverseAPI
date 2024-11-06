using AutoMapper;
using CoinverseSocialAPI.DTO;
using CoinverseSocialAPI.Models;

namespace CoinverseSocialAPI.Infrastructure.Mapping
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {

            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();

            // CreateMap<UserModel, UserCreateDto>();
            // CreateMap<UserCreateDto, UserModel>();
            // CreateMap<UserModel, UserMinUpdateDTO>();
            // CreateMap<UserMinUpdateDTO, UserModel>();
        }
    }
}
