using System;
using CoinverseSocialAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinverseSocialAPI.Models
{
    public class Follower
    {
        [Key]
        public int Id { get; set; }

        public int FkUser { get; set; }

        [ForeignKey("FkUser")]
        public UserModel User { get; set; }

        public int FkFollower { get; set; }

        [ForeignKey("FkFollower")]
        public UserModel FollowerUser { get; set; }

        public DateTime? FollowDate { get; set; }
    }
}
