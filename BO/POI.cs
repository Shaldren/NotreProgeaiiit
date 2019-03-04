using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class POI
    {
        [Key]
        [ForeignKey("Race")]
        public int Race { get; set; }
        [Key]
        public int Order { get; set; }        
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int Category { get; set; }
        public double CooX { get; set; }
        public double CooY { get; set; }

        
        
    }
}
