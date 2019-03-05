using BO.Auth;
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
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<POI> Positions { get; set; }
        public virtual Race Race { get; set; }

        [Display(Name = "Date d'inscription")]
        public DateTime DateInscription { get; set; }

    }
}
