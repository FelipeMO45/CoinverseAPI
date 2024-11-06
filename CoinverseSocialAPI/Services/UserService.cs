using CoinverseSocialAPI.Context;
using CoinverseSocialAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CoinverseSocialAPI.Services;
using System;
using CoinverseSocialAPI.DTO;
using AutoMapper;

namespace CoinverseSocialAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Crear usuario

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<UserModel>(userDto);
                user.Date = DateTime.Now;
                _context.sUser.Add(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        // Obtener usuario por id

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _context.sUser.FindAsync(id);
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        // Listar todos los usuarios

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            try
            {
                var users = await _context.sUser.ToListAsync();
                return _mapper.Map<IEnumerable<UserModel>>(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // Actualizar parte del usuario

        public async Task<UserDto> UpdateUserAsync(int id, UserMinUpdateDTO userUpdateDto)
        {
            try
            {
                var user = await _context.sUser.FindAsync(id);
                if (user == null)
                {
                    return null;
                }

                _mapper.Map(userUpdateDto, user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        // Metodos para Follow y Unfollow

        public async Task<bool> FollowUserAsync(int userId, int followerId)
        {
            if (userId == followerId || await _context.Followers.AnyAsync(f => f.FkUser == userId && f.FkFollower == followerId))
            {
                return false;
            }

            var follower = new Follower
            {
                FkUser = userId,
                FkFollower = followerId,
                FollowDate = DateTime.Now
            };

            _context.Followers.Add(follower);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnfollowUserAsync(int userId, int followerId)
        {
            var followerRecord = await _context.Followers.FirstOrDefaultAsync(f => f.FkUser == userId && f.FkFollower == followerId);
            if (followerRecord == null)
            {
                return false;
            }

            _context.Followers.Remove(followerRecord);
            await _context.SaveChangesAsync();
            return true;
        }

        // Listar seguidores y seguidos totales
        public async Task<IEnumerable<UserModel>> GetFollowersAsync(int userId)
        {
            try
            {
                var followerIds = await _context.Followers
                    .Where(f => f.FkUser == userId)
                    .Select(f => f.FkFollower)
                    .ToListAsync();

                var followers = await _context.sUser
                .Where(u => followerIds.Contains(u.PkUser))
                .ToListAsync();

                return _mapper.Map<IEnumerable<UserModel>>(followers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error al obtener los seguidores.");
            }
        }

        public async Task<IEnumerable<UserModel>> GetFollowingAsync(int userId)
        {
            try
            {
                var followingIds = await _context.Followers
                    .Where(f => f.FkFollower == userId)
                    .Select(f => f.FkUser)
                    .ToListAsync();

                var followingUsers = await _context.sUser
                .Where(u => followingIds.Contains(u.PkUser))
                .ToListAsync();

                return _mapper.Map<IEnumerable<UserModel>>(followingUsers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error al obtener los usuarios seguidos.");
            }
        }

        // Contar seguidores
        public async Task<int> GetFollowersCountAsync(int userId)
        {
            try
            {
                return await _context.Followers.CountAsync(f => f.FkFollower == userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error al obtener el conteo de seguidores.");
            }
        }

        // Contar seguidos
        public async Task<int> GetFollowingCountAsync(int userId)
        {
            try
            {
                return await _context.Followers.CountAsync(f => f.FkUser == userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error al obtener el conteo de usuarios seguidos.");
            }
        }
    }
}