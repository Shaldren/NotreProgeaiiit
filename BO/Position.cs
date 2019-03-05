using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Position
    {
        public int Order { get; set; }
        public int Race_Id { get; set; }
        public virtual Race Race { get; set; }
        public int POI_Id { get; set; }
        public virtual POI POI { get; set; }
    }
}
