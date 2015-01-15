using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Common
{
    public static class CustomExtension
    {
        /// <summary>
        /// 动态排序扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="ascending">是否升序</param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending) where T : class
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null)
                throw new ArgumentException("propertyName", "Not Exist");

            ParameterExpression param = Expression.Parameter(type, "p");
            Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);

            string methodName = ascending ? "OrderBy" : "OrderByDescending";

            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<T>(resultExp);
        }

        /// <summary>
        /// 动态排序扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="order">"asc"或"desc"</param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, string order) where T : class
        {
            order = order.ToUpper();

            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null)
                throw new ArgumentException("propertyName", "Not Exist");

            ParameterExpression param = Expression.Parameter(type, "p");
            Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);

            string methodName = order == "ASC" ? "OrderBy" : "OrderByDescending";

            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
