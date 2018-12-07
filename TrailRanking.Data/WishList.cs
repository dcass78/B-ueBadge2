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
        public Guid OwnerId { get; set; }
        
        public int TrailId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual Trail Trail { get; set; }
    }
}
