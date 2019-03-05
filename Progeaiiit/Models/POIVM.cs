using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Progeaiiit.Models
{
    public class POIVM
    {
        public POI POI { get; set; }
        public List<Category> Categories { get; set; }
        public List<int> IdSelectedCategory { get; set; }
    }
}