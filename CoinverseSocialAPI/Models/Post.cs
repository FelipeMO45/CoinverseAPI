using CoinverseSocialAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinverseSocialAPI.Models
{
    public class Post
    {
        [Key]
        public int PkPost { get; set; }

        public int? FkUser { get; set; }

        [ForeignKey("FkUser")]
        public UserModel? User { get; set; }

        public DateTime Date { get; set; }

        public int FkTypePost { get; set; }

        [ForeignKey("FkTypePost")]
        public cTypePost? TypePost { get; set; }

        [Column("text")]
        public string? Text { get; set; }

        public int? IdPostShared { get; set; }

        [ForeignKey("IdPostShared")]
        public Post? SharedPost { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }
}
