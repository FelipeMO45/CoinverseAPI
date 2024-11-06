using CoinverseSocialAPI.Models;
using CoinverseSocialAPI.DTO;
using System.Threading.Tasks;

namespace CoinverseSocialAPI.Services
{
    public interface IPostService
    {
        Task<PostDTO> CreatePostAsync(PostDTO postDto);
        Task<PostDTO> GetPostByIdAsync(int id);
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<bool> LikePostAsync(int postId, int userId, int typeLikeId);
        Task<bool> UnlikePostAsync(int userId, int postId);
        Task<int> GetLikesCountAsync(int postId);
    }
}
