using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Progeaiiit.Models
{
	public class RaceVM
	{
		public Race Race { get; set; }
		public List<POI> POIs { get; set; }
		public List<Inscription> Inscriptions { get; set; }
		public List<int> IdSelectedPOI { get; set; }
		public List<int> IdSelectedInscription { get; set; }
	}
}