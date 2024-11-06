using CoinverseSocialAPI.Models;
using CoinverseSocialAPI.Services;
using CoinverseSocialAPI.Context;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoinverseSocialAPI.DTO;
using AutoMapper;

namespace CoinverseSocialAPI.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create post
        public async Task<PostDTO> CreatePostAsync(PostDTO postDto)
        {
            try
            {
                var post = _mapper.Map<Post>(postDto);
                post.Date = DateTime.Now;
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return _mapper.Map<PostDTO>(post);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // Get post by id
        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            try
            {
                var post = await _context.Posts.Include(p => p.User).Include(p => p.TypePost).FirstOrDefaultAsync(p => p.PkPost == id);
                return _mapper.Map<PostDTO>(post);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // List all posts
        public async Task<IEnumerable<PostDTO>> GetAllPostsAsync()
        {
            try
            {
                var posts = await _context.Posts.Include(p => p.User).Include(p => p.TypePost).ToListAsync();
                return _mapper.Map<IEnumerable<PostDTO>>(posts);  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // Like post
        public async Task<bool> LikePostAsync(int postId, int userId, int typeLikeId)
        {
            try
            {
                var likePostDto = new LikePostDto
                {
                    FkUser = userId,
                    FkTypeLike = typeLikeId
                };

                var like = _mapper.Map<Like>(likePostDto);
                like.FkPost = postId;

                _context.Likes.Add(like);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Unlike post
        public async Task<bool> UnlikePostAsync(int userId, int postId)
        {
            try
            {
                var like = await _context.Likes
                    .FirstOrDefaultAsync(l => l.FkUser == userId && l.FkPost == postId);

                if (like == null)
                {
                    return false;
                }

                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Get likes count
        public async Task<int> GetLikesCountAsync(int postId)
        {
            try
            {
                return await _context.Likes.CountAsync(l => l.FkPost == postId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error al contar los likes del post.");
            }
        }
    }
}
