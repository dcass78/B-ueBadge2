using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class TrailEdit
    {
        public int TrailId { get; set; }
        public string TrailName { get; set; }
        public string Description { get; set; }
        public int EquipmentId { get; set; }
        public int TrailRank { get; set; }
        public string Location { get; set; }
    }
}
