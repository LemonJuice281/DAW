using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class Player
    {
        [Key]
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPosition { get; set; }
        public string PlayerTeam { get; set; }
        public string NoOfGoals { get; set; }
    }
}
