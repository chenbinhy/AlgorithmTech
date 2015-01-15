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
    public class TagBLL:BaseBLL, ITagBLL
    {
        private ITagDAL m_TagDAL;

        public TagBLL(ITagDAL tagDAL)
            : base(tagDAL)
        {
            m_TagDAL = tagDAL;
        }
    }
}
