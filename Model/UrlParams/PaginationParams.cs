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
    public class PaginationParams
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
