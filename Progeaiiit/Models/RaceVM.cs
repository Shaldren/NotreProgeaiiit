using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Progeaiiit.Models
{
	public class RaceVM
	{
		public Race Race { get; set; }
		public List<SelectListItem> POIs { get; set; }
		public List<SelectListItem> Inscriptions { get; set; }
		public List<int> IdSelectedPOI { get; set; }
		public List<int> IdSelectedInscription { get; set; }
	}
}