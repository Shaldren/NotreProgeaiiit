using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Auth
{
    public partial class ApplicationUser
    {
        public int id { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
        public ICollection<DisplayConfiguration> DisplayConfigurations { get; set; }
        public virtual ICollection<Race> Races { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string phone { get; set; }
    }
}
