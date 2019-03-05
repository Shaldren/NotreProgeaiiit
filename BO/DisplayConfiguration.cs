using BO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class DisplayConfiguration
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string DeviceName { get; set; }
        public Guid Id { get; set; }
        public bool SpeedAvg { get; set; }
        public bool SpeedMax { get; set; }
        public string UnitDistance { get; set; }
    }
}
