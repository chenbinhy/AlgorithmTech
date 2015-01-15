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
    public class CommentBLL:BaseBLL, ICommentBLL
    {
        private ICommentDAL m_CommentDAL;

        public CommentBLL(ICommentDAL commentDAL)
            : base(commentDAL)
        {
            m_CommentDAL = commentDAL;
        }
    }
}
