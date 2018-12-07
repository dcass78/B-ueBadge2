using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class EquipmentListItem
    {
        [Display(Name = "Equipment Id")]
        public int EquipmentId { get; set; }
        [Display(Name = "Equipment Name")]
        public string EquipmentName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
