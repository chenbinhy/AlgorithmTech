using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dylan.AlgorithmTech.Model;
using PagedList;

namespace Dylan.AlgorithmTech.IBLL
{
    public interface IBaseBLL
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Insert<T>(T entity) where T : class;

        /// <summary>
        /// 新增多个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        List<T> Insert<T>(List<T> entities) where T : class;

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// 删除多个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        void Delete<T>(List<T> entities) where T : class;

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        void CustomDelete<T>(Expression<Func<T, bool>> conditions) where T : DeletableObject;

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update<T>(T entity) where T : class;

        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        List<T> Update<T>(List<T> entities) where T : class;

        /// <summary>
        /// 根据主键查找实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T Find<T>(params object[] keyValues) where T : class;

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <returns></returns>
        List<T> FindAll<T>(Expression<Func<T, bool>> conditions = null) where T : class;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <param name="pasgeSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IPagedList<T> FindAllByPage<T>(Expression<Func<T, bool>> conditions, string sort, string order, int pageSize, int pageIndex) where T : class;

        /// <summary>
        /// 根据条件，计算数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <returns></returns>
        int GetCount<T>(Expression<Func<T, bool>> conditions) where T : class;
    }
}
