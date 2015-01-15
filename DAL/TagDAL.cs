using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dylan.AlgorithmTech.IDAL;
using Dylan.AlgorithmTech.Model;

namespace Dylan.AlgorithmTech.DAL
{
    public class TagDAL:BaseDAL,ITagDAL
    {
        public TagDAL(ATTDbContext context)
            : base(context)
        {
        }
    }
}
