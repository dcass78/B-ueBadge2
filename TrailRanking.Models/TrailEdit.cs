using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class TrailEdit
    {
        [Display(Name = "Trail Id")]
        public int TrailId { get; set; }
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Equipment ")]
        public int EquipmentId { get; set; }
        [Display(Name = "Trail Rank")]
        public int TrailRank { get; set; }
        public string Location { get; set; }
    }
}
