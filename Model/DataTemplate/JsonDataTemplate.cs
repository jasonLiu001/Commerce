using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTemplate
{
    public class JsonDataTemplate<T> where T: new()
    {
        public string name { get; set; }
        public string type { get; set; }
        public List<T> children { get; set; }
    }
}
