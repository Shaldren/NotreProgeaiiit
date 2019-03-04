using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Inscription
    {
        [Key]
        public int Number { get; set; }
        [ForeignKey("AspNetUsers")]
        public string ApplicationUserId { get; set; }        

        [ForeignKey("POI")]
        public List<POI> Position { get; set; }

        [ForeignKey("Race")]
        public int RaceId { get; set; }
    }
}
