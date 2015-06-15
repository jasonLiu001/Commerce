using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RegionDetail
    {
        public string region_code { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string parent_region_code { get; set; }
        public string area_code { get; set; }
        public string region_rank { get; set; }
        public string area_category { get; set; } 
    }
}
