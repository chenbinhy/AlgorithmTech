using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

using PagedList;

using Dylan.AlgorithmTech.IDAL;
using Dylan.AlgorithmTech.Model;
using Dylan.AlgorithmTech.Common;

namespace Dylan.AlgorithmTech.DAL
{
    public class BaseDAL:IBaseDAL,IDisposable
    {
        private ATTDbContext m_ATTDbContext;

        public BaseDAL(ATTDbContext dbContext)
        {
            m_ATTDbContext = dbContext;
        }

        public T Insert<T>(T entity) where T : class
        {
            m_ATTDbContext.Set<T>().Add(entity);
            m_ATTDbContext.SaveChanges();

            return entity;
        }

        public List<T> Insert<T>(List<T> entities) where T : class
        {
            m_ATTDbContext.Set<T>().AddRange(entities);
            m_ATTDbContext.SaveChanges();

            return entities;
        }

        public void Delete<T>(T entity) where T : class
        {
            m_ATTDbContext.Entry<T>(entity).State = EntityState.Deleted;
            m_ATTDbContext.SaveChanges();
        }

        public void Delete<T>(List<T> entities) where T : class
        {
            foreach (T t1 in entities)
            {
                m_ATTDbContext.Entry<T>(t1).State = EntityState.Deleted;
            }
            m_ATTDbContext.SaveChanges();
        }

        public void CustomDelete<T>(System.Linq.Expressions.Expression<Func<T, bool>> conditions) where T : DeletableObject
        {
            m_ATTDbContext.Set<T>().Where<T>(conditions).First<T>().IsDeleted = true;
            m_ATTDbContext.SaveChanges();
        }

        public T Update<T>(T entity) where T : class
        {
            m_ATTDbContext.Entry<T>(entity).State = EntityState.Modified;
            m_ATTDbContext.SaveChanges();

            return entity;
        }

        public List<T> Update<T>(List<T> entities) where T : class
        {
            foreach (T t1 in entities)
            {
                m_ATTDbContext.Entry<T>(t1).State = EntityState.Modified;
            }
            m_ATTDbContext.SaveChanges();

            return entities;
        }

        public T Find<T>(params object[] keyValues) where T : class
        {
            return m_ATTDbContext.Set<T>().Find(keyValues);
        }

        public List<T> FindAll<T>(System.Linq.Expressions.Expression<Func<T, bool>> conditions = null) where T : class
        {
            if (conditions == null)
            {
                return m_ATTDbContext.Set<T>().ToList<T>();
            }
            else
            {
                return m_ATTDbContext.Set<T>().Where(conditions).ToList();
            }
        }

        public PagedList.IPagedList<T> FindAllByPage<T>(System.Linq.Expressions.Expression<Func<T, bool>> conditions, string sort, string order, int pageSize, int pageIndex) where T : class
        {
            var queryList = conditions == null ? m_ATTDbContext.Set<T>() : m_ATTDbContext.Set<T>().Where(conditions) as IQueryable<T>;
            var r = queryList.OrderBy(sort, order);

            return r.ToPagedList(pageIndex, pageSize);
        }

        public int GetCount<T>(System.Linq.Expressions.Expression<Func<T, bool>> conditions) where T : class
        {
            if (conditions == null)
            {
                return m_ATTDbContext.Set<T>().Count();
            }
            else
            {
                return m_ATTDbContext.Set<T>().Where(conditions).Count();
            }
        }

        public void Dispose()
        {
            if (m_ATTDbContext != null)
            {
                m_ATTDbContext.Dispose();
            }
        }
    }
}
