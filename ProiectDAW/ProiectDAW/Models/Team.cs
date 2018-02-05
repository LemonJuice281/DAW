using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class Team
    {
        [Key]
        public string TeamName { get; set; }
        public string Country { get; set; }
        public string Championship { get; set; }
        public string Ranking { get; set; }
    }
}
