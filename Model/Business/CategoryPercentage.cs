using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    /// <summary>
    /// 类型分布
    /// </summary>
   public class CategoryPercentage
    {
       public int id { get; set; }
       public int news { get; set; }
       public int blog { get; set; }
       public int forum { get; set; }
       public int media { get; set; }
       public int weibo { get; set; }
       public int weixin { get; set; }
       public int total_counts { get; set; }
    }
}
