using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CoinverseSocialAPI.Models
{
    public class UserModel
    {
        [Key]
        public int PkUser { get; set; }

        [Column("fullName")]
        public string FullName { get; set; }

        [Column("userName")]
        public string? UserName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("biography")]
        public string? Biography { get; set; }

        [Column("website")]
        public string? Website { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

        [Column("photo")]
        public string? Photo { get; set; }

        [Column("isOnline")]
        public bool IsOnline { get; set; }

        public ICollection<Post>? Posts { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Follower>? Followers { get; set; }
        public ICollection<Follower>? Following { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }
}
