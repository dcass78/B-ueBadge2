using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class WishListDetail
    {
        public int WishListId { get; set; }
        public int TrailId { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
