using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Data
{
    public class Trail
    {
        [Key]
        public int TrailId { get; set; }
        [Required]
        public string TrailName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "please choose a number between 1 and 5")]
        public int TrailRank { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
