using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinverseSocialAPI.Models
{
    public class cTypePost
    {
        [Key]
        public int PkTypePost {  get; set; }

        [Column("name")]
        public string Name { get; set; }

        // Referencia a tabla post
        public ICollection<Post> Posts { get; set; }
    }
}
