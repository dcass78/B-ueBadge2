using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailRanking.Data;

namespace TrailRanking.Models
{
    public class TrailListItem
    {
        [Display(Name = "Trail Id")]
        public int TrailId { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        [Display(Name = "Equipment Id")]
        public int EquipmentId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public override string ToString() => TrailName;
        public virtual Equipment Equipment { get; set; }
    }
}
