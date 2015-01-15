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
    public class ArticleImageBLL:BaseBLL, IArticleImageBLL
    {
        private IArticleImageDAL m_ArticleImageDAL;

        public ArticleImageBLL(IArticleImageDAL articleImageDAL)
            : base(articleImageDAL)
        {
            m_ArticleImageDAL = articleImageDAL;
        }
    }
}
