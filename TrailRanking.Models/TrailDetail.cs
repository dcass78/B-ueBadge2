using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class TrailDetail
    {
        public int TrailId { get; set; }
        public string TrailName { get; set; }
        public string Description { get; set; }
        public int TrailRank { get; set; }
        public string Location { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{TrailId}] {TrailName}";
    }
}
