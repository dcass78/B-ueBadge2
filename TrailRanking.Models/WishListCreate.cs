using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class WishListCreate
    {
        [Required]
        public int TrailId { get; set; }
        public string TrailName { get; set; }
        public string Location { get; set; }
    }
}
