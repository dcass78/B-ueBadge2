using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class EquipmentDetail
    {
        [Required]
        public int EquipmentId { get; set; }
        [Required]
        public string EquipmentName { get; set; }
        [Required]
        public string EquipmentUse { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
