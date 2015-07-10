using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UrlParams
{
    /// <summary>
    /// 来源数据类型
    /// </summary>
    public class PostRequestDataParams
    {
        public string dataType
        {
            get;
            set;
        }
        public string queryDate
        {
            get;
            set;
        }
        public string topCount
        {
            get;
            set;
        }
    }
}
