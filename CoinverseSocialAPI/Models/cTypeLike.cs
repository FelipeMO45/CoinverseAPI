using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinverseSocialAPI.Models
{
    public class cTypeLike
    {
        [Key]
        public int PkTypeLike { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Like> Likes { get; set; }
    }

}
