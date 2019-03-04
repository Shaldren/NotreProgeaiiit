using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
                
        public List<Inscription> Inscriptions { get; set; }
        public List<POI> Pois { get; set; }        
        
    }
}
