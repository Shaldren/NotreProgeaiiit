using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Auth
{
    public partial class ApplicationUser
    {

        public virtual ICollection<Inscription> Inscriptions { get; set; }
        public virtual DisplayConfiguration DisplayConfiguration { get; set; }
    }
}
