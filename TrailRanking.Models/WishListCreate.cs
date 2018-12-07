using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailRanking.Data;

namespace TrailRanking.Models
{
    public class WishListCreate
    {
        [Required]
        public int TrailId { get; set; }
        
    }
}
