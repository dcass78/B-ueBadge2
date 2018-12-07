using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Data
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string EquipmentName { get; set; }
        [Required]
        public string EquipmentUse { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
