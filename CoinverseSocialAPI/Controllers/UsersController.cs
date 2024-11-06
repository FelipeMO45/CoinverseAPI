using CoinverseSocialAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CoinverseSocialAPI.Models;
using CoinverseSocialAPI.DTO;
using System.Threading.Tasks;
using AutoMapper;

namespace CoinverseSocialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            
            _userService = userService;
        }

        /// Crear un usuario
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
        {
            try
            {
                var createdUserDto = await _userService.CreateUserAsync(userDto);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUserDto.PkUser }, createdUserDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// Obtener un usuario por id
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            try
            {
                var userDto = await _userService.GetUserByIdAsync(id);
                if (userDto == null)
                {
                    return NotFound();
                }

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// Obtener todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            try
            {
                var usersDto = await _userService.GetAllUsersAsync();
                return Ok(usersDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// Actualizar parte de un usuario
        [HttpPatch("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, UserMinUpdateDTO userUpdateDto)
        {
            try
            {
                var updatedUserDto = await _userService.UpdateUserAsync(id, userUpdateDto);
                if (updatedUserDto == null)
                {
                    return NotFound();
                }

                return Ok(updatedUserDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// Seguir a un usuario
        [HttpPost("{userId}/follow/{followerId}")]
        public async Task<IActionResult> FollowUser(int userId, int followerId)
        {
            try
            {
                var result = await _userService.FollowUserAsync(userId, followerId);
                if (!result)
                {
                    return BadRequest("No se pudo seguir al usuario.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
            
        }

        /// Dejar de seguir a un usuario
        [HttpPost("{userId}/unfollow/{followerId}")]
        public async Task<IActionResult> UnfollowUser(int userId, int followerId)
        {
            try
            {
                var result = await _userService.UnfollowUserAsync(userId, followerId);
                if (!result)
                {
                    return BadRequest("No se pudo dejar de seguir al usuario.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// Lista de seguidores de un usuario
        [HttpGet("{userId}/followers")]
        public async Task<IActionResult> GetFollowers(int userId)
        {
            var followers = await _userService.GetFollowersAsync(userId);
            if (followers == null)
            {
                return NotFound("No se encontraron seguidores.");
            }
            return Ok(followers);
        }

        /// Lista de usuarios seguidos por un usuario
        [HttpGet("{userId}/following")]
        public async Task<IActionResult> GetFollowing(int userId)
        {
            var following = await _userService.GetFollowingAsync(userId);
            if (following == null)
            {
                return NotFound("No se encontraron usuarios seguidos.");
            }
            return Ok(following);
        }

        /// Contar seguidores de un usuario
        [HttpGet("{userId}/followers/count")]
        public async Task<ActionResult<int>> GetFollowersCount(int userId)
        {
            try
            {
                var count = await _userService.GetFollowersCountAsync(userId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// Contar usuarios seguidos por un usuario
        [HttpGet("{userId}/following/count")]
        public async Task<ActionResult<int>> GetFollowingCount(int userId)
        {
            try
            {
                var count = await _userService.GetFollowingCountAsync(userId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
