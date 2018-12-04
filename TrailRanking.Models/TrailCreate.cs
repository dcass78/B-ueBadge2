using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class TrailCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string TrailName { get; set; }
        [MaxLength(8000)]
        public string Description { get; set; }
        public int TrailRank { get; set; }
        public string Location { get; set; }

        public override string ToString() => TrailName;
    }
}
