using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class WishListEdit
    {
        [Display(Name = "Wish List Id")]
        public int WishListId { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        [Display(Name = "Trail Id")]
        public int TrailId { get; set; }
    }
}
