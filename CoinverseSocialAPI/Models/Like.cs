using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinverseSocialAPI.Models
{
    public class Like
    {
        [Key]
        public int PkLike { get; set; }
        public int FkUser { get; set; }
        [ForeignKey("FkUser")]
        public UserModel User { get; set; }
        public int FkPost { get; set; }
        [ForeignKey("FkPost")]
        public Post Post { get; set; }
        public int FkTypeLike { get; set; }
        [ForeignKey("FkTypeLike")]
        public cTypeLike TypeLike { get; set; }
        public DateTime? Date { get; set; }  
    }

}
