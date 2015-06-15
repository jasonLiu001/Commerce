using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {
        public int id { get; set; }
        public string title { get; set; }
        public string site_name { get; set; }
        public string url { get; set; }
        public string media_type { get; set; }
        public int polarity { get; set; }
        public DateTime publish_date { get; set; }
        public string same_doc_id { get; set; }
        public int same_doc_count { get; set; }
        public string address { get; set; }
        public string content { get; set; }
    }
}
