using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinverseSocialAPI.Models
{
    public class Comment
    {
        [Key]
        public int PkComment { get; set; }

        [Required]
        public string Text { get; set; }

        public int? FkUser { get; set; }

        [ForeignKey("FkUser")]
        public UserModel? User { get; set; }

        public int FkPost { get; set; }

        [ForeignKey("FkPost")]
        public Post Post { get; set; }

        public DateTime Date { get; set; }
    }
}

