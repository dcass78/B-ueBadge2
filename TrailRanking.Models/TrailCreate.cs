﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRanking.Models
{
    public class TrailCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string TrailName { get; set; }
        [MaxLength(8000)]
        public string Description { get; set; }
        public int TrailRank { get; set; }
        public string Location { get; set; }

        public override string ToString() => TrailName;
    }
}
