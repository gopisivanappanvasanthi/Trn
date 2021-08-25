using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trn.Feature.Article.Models;

namespace Trn.Feature.Article.Repositories
{
    public interface ITrnArticleRepository
    {
        ArticleInfo GetArticleInfo(bool IsFeaturedArticle = false);
    }
}
