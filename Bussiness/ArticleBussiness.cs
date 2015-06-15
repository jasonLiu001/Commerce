using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class ArticleBussiness
    {
        ArticleDataAccesser articleDataAccesser = new ArticleDataAccesser();
        public List<Article> GetArticleList()
        {
            return articleDataAccesser.GetArticleList();
        }
    }
}
