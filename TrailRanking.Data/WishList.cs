using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Data
{
    public class WishList
    {
        [Key]
        public int WishListId { get; set; }
        [Required]
        public string Trail { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{WishListId}] {Trail}";
    }
}
