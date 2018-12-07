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
        public int EquipmentId { get; set; }
        [Required]
        public string EquipmentUse { get; set; }
        [Required]
        [MaxLength(8000)]
        public string EquipmentName { get; set; }
    }
}
