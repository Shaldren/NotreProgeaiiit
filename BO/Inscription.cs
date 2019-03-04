using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Inscription
    {
		public int Id { get; set; }
        public float Amount { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public int Number { get; set; }
        public List<POI> Position { get; set; }
        public Race Race { get; set; }
        public int RaceId { get; set; }
    }
}
