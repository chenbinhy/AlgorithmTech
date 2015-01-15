using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dylan.AlgorithmTech.DAL;
using Dylan.AlgorithmTech.IBLL;
using Dylan.AlgorithmTech.IDAL;

namespace Dylan.AlgorithmTech.BLL
{
    public class ArticleBLL:BaseBLL, IArticleBLL
    {
        private IArticleDAL m_ArticleDAL;

        public ArticleBLL(IArticleDAL articleDAL)
            : base(articleDAL)
        {
            m_ArticleDAL = articleDAL;
        }
    }
}
