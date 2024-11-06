using CoinverseSocialAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinverseSocialAPI.Services
{
    public interface ICommentService
    {
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
        Task<Comment> UpdateCommentAsync(int commentId, Comment updatedComment);
        Task DeleteCommentAsync(int commentId);
        Task<Comment> GetCommentByIdAsync(int commentId);
    }
}
