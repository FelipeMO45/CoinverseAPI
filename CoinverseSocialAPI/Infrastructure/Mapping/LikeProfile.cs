using AutoMapper;
using CoinverseSocialAPI.DTO;
using CoinverseSocialAPI.Models;

namespace CoinverseSocialAPI.Infrastructure.Mapping
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<Like, LikePostDto>();
            CreateMap<LikePostDto, Like>();
            CreateMap<Like, UnlikePostDto>();
            CreateMap<UnlikePostDto, Like>();
        }
    }
}
