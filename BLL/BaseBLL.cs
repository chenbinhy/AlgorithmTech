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
    public class BaseBLL:IBaseBLL
    {
        private IBaseDAL m_BaseDAL;

        public BaseBLL(IBaseDAL baseDAL)
        {
            m_BaseDAL = baseDAL;
        }

        public T Insert<T>(T entity) where T : class
        {
            return m_BaseDAL.Insert<T>(entity);
        }

        public List<T> Insert<T>(List<T> entities) where T : class
        {
            return m_BaseDAL.Insert<T>(entities);
        }

        public void Delete<T>(T entity) where T : class
        {
            m_BaseDAL.Delete<T>(entity);
        }

        public void Delete<T>(List<T> entities) where T : class
        {
            m_BaseDAL.Delete<T>(entities);
        }

        public void CustomDelete<T>(System.Linq.Expressions.Expression<Func<T, bool>> conditions) where T : Model.DeletableObject
        {
            m_BaseDAL.CustomDelete<T>(conditions);
        }

        public T Update<T>(T entity) where T : class
        {
            return m_BaseDAL.Update<T>(entity);
        }

        public List<T> Update<T>(List<T> entities) where T : class
        {
            return m_BaseDAL.Update<T>(entities);
        }

        public T Find<T>(params object[] keyValues) where T : class
        {
            return m_BaseDAL.Find<T>(keyValues);
        }

        public List<T> FindAll<T>(System.Linq.Expressions.Expression<Func<T, bool>> conditions = null) where T : class
        {
            return m_BaseDAL.FindAll<T>(conditions);
        }

        public PagedList.IPagedList<T> FindAllByPage<T>(System.Linq.Expressions.Expression<Func<T, bool>> conditions, string sort, string order, int pageSize, int pageIndex) where T : class
        {
            return m_BaseDAL.FindAllByPage<T>(conditions, sort, order, pageSize, pageIndex);
        }

        public int GetCount<T>(System.Linq.Expressions.Expression<Func<T, bool>> conditions) where T : class
        {
            return m_BaseDAL.GetCount<T>(conditions);
        }
    }
}
