using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class DisplayConfiguration
    {
        //public ApplicationUser ApplicationUser { get; set; }
        public string DeviceName { get; set; }
        public Guid Id { get; set; }
        public bool SpeedAvg { get; set; }
        public bool SpeedMax { get; set; }
        public string UnitDistance { get; set; }
    }
}
