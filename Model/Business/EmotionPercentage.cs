using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class EmotionPercentage
    {
        public int id { get; set; }
        public int positive{get;set;}
        public int negative { get; set; }
        public int normal { get; set; }
        public int total_counts { get; set; }
    }
}
