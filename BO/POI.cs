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
        public int Id { get; set; }
        public Race Race { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public double CooX { get; set; }
        public double CooY { get; set; }

        public virtual ICollection<Inscription> Inscriptions { get; set; }

        
        
    }
}
