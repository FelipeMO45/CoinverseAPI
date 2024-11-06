using Microsoft.AspNetCore.Mvc;
using CoinverseSocialAPI.Models;
using CoinverseSocialAPI.Services;
using CoinverseSocialAPI.DTO;
using CoinverseSocialAPI.Context;
using System.Threading.Tasks;

namespace CoinverseSocialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<ActionResult<PostDTO>> CreatePost(PostDTO postDto)
        {
            try
            {
                var createdPostDto = await _postService.CreatePostAsync(postDto);
                return CreatedAtAction(nameof(GetPostById), new { id = createdPostDto.PkPost }, createdPostDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPostById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetAllPosts()
        {
            try
            {
                var posts = await _postService.GetAllPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{postId}/like")]
        public async Task<IActionResult> LikePost(int postId, [FromBody] LikePostDto likePostDto)
        {
            try
            {
                var result = await _postService.LikePostAsync(postId, likePostDto.FkUser, likePostDto.FkTypeLike);
                if (!result)
                {
                    return BadRequest("No se pudo dar like al post.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{postId}/like")]
        public async Task<IActionResult> UnlikePost(int postId, [FromBody] UnlikePostDto unlikePostDto)
        {
            try
            {
                var result = await _postService.UnlikePostAsync(unlikePostDto.FkUser, postId);
                if (!result)
                {
                    return BadRequest("No se pudo quitar el like del post.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{postId}/likes/count")]
        public async Task<IActionResult> GetLikesCount(int postId)
        {
            try
            {
                var count = await _postService.GetLikesCountAsync(postId);
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
