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

    public class CompassDataTemplate<T1, T2, T3>
        where T1 : new()
        where T2 : new()
        where T3 : new()
    {
        public string name { get; set; }
        public string type { get; set; }
        public List<T1> children1 { get; set; }
        public List<T2> children2 { get; set; }
        public List<T3> children3 { get; set; }
    }

    public class CommonDataEntity
    {
        public string name { get; set; }
        public string type { get; set; }
    }
}
