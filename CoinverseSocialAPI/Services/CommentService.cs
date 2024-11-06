using CoinverseSocialAPI.Context;
using CoinverseSocialAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinverseSocialAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            try
            {
                comment.Date = DateTime.Now;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return comment;
            }
            catch (Exception ex)
            {
                // Considera loguear la excepción
                throw new ApplicationException("An error occurred when creating the comment.", ex);
            }
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            try
            {
                return await _context.Comments
                    .Where(c => c.FkPost == postId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Considera loguear la excepción
                throw new ApplicationException($"An error occurred when retrieving comments for post {postId}.", ex);
            }
        }

        public async Task<Comment> UpdateCommentAsync(int commentId, Comment updatedComment)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                if (comment == null)
                {
                    throw new KeyNotFoundException("Comment not found.");
                }

                comment.Text = updatedComment.Text;
                // Aquí puedes actualizar otros campos según sea necesario

                await _context.SaveChangesAsync();
                return comment;
            }
            catch (Exception ex)
            {
                // Considera loguear la excepción
                throw new ApplicationException($"An error occurred when updating the comment with ID {commentId}.", ex);
            }
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                if (comment == null)
                {
                    throw new KeyNotFoundException("Comment not found.");
                }

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Considera loguear la excepción
                throw new ApplicationException($"An error occurred when deleting the comment with ID {commentId}.", ex);
            }
        }
    }
}
