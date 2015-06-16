using DataAccess;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class HotWordsBussiness
    {
        HotWordsDataAccesser hotWordsDataAccesser = new HotWordsDataAccesser();
        public List<JsonDataTemplate<HotWord>> GetHotWords()
        {
            var list = new List<JsonDataTemplate<HotWord>>();
            var jsonData = new JsonDataTemplate<HotWord>();
            var hotWordsList = hotWordsDataAccesser.GetHotWordsList();
            jsonData.name = "大数据";
            jsonData.type = "root";
            jsonData.children = hotWordsList;
            list.Add(jsonData);
            return list;
        }
    }
}
