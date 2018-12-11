using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class EquipmentCreate
    {
        [Key]
        [Display(Name = "Equipment Id")]
        public int EquipmentId { get; set; }
        [Required]
        [Display(Name = "Equipment Use")]
        public string EquipmentUse { get; set; }
        [Required]
        [MaxLength(8000)]
        [Display(Name = "Equipment Name")]
        public string EquipmentName { get; set; }
    }
}
