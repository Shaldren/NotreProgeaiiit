using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Progeaiiit.Models
{
    public class CategoryVM
    {
        public Category Category { get; set; }
        public List<POI> POIs { get; set; }
        public List<int> IdSelectedPOI { get; set; }
    }
}