using CoinverseSocialAPI.Models;
using CoinverseSocialAPI.DTO;
using System.Threading.Tasks;

namespace CoinverseSocialAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserDto> UpdateUserAsync(int id, UserMinUpdateDTO userUpdateDto);
        Task<bool> FollowUserAsync(int userId, int followerId);
        Task<bool> UnfollowUserAsync(int userId, int followerId);
        Task<IEnumerable<UserModel>> GetFollowersAsync(int userId);
        Task<IEnumerable<UserModel>> GetFollowingAsync(int userId);
        Task<int> GetFollowersCountAsync(int userId);
        Task<int> GetFollowingCountAsync(int userId);
    }
}
