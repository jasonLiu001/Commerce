using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataTemplate
{
    public class CompassJsonDataTemplate<T> where T: new()
    {
        public string name { get; set; }

        private string _type = "root";
        public string type {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        private List<T> _childrend = null;
        public List<T> children
        {
            get
            {
                return _childrend;
            }
            set
            {
                _childrend = value;
            }
        }

        private string _errorMsg = null;
        public string errorMsg {
            get
            {
                return _errorMsg;
            }
            set
            {
                _errorMsg = value;
            }
        }
    }

    public class CompassDataFirstChild<T> where T : new()
    {
        public string name { get; set; }
        public string type { get; set; }
        private List<T> _childrend = null;
        public List<T> children
        {
            get
            {
                return _childrend;
            }
            set
            {
                _childrend = value;
            }
        }
    }

    public class CompassDataLastChild
    {
        public string name { get; set; }
        public string type { get; set; }
    }

}
