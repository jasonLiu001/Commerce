using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UrlParams
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class UrlParams
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }

    /// <summary>
    /// 来源数据类型
    /// </summary>
    public class SourceDataType
    {
        public string dataType { get; set; }
        public string queryDate { get; set; }
    }
}
