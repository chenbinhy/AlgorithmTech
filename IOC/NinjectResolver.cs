using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dylan.AlgorithmTech.BLL;
using Dylan.AlgorithmTech.DAL;
using Dylan.AlgorithmTech.IBLL;
using Dylan.AlgorithmTech.IDAL;
using Ninject;

namespace Dylan.AlgorithmTech.IOC
{
    public class NinjectResolver : IDependencyResolver,IDisposable
    {
        private IKernel m_Kernel;

        public NinjectResolver()
        {
            m_Kernel = new StandardKernel();
        }

        public object GetService(Type serviceType)
        {
            return m_Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return m_Kernel.GetAll(serviceType);
        }

        private void AddBinding()
        {
            m_Kernel.Bind<IBaseDAL>().To<BaseDAL>();
            m_Kernel.Bind<ICommentDAL>().To<CommentDAL>();
            m_Kernel.Bind<ITagDAL>().To<TagDAL>();
            m_Kernel.Bind<IArticleDAL>().To<ArticleDAL>();
            m_Kernel.Bind<IArticleImageDAL>().To<ArticleImageDAL>();

            m_Kernel.Bind<IBaseBLL>().To<BaseBLL>();
            m_Kernel.Bind<ICommentBLL>().To<CommentBLL>();
            m_Kernel.Bind<ITagBLL>().To<TagBLL>();
            m_Kernel.Bind<IArticleBLL>().To<ArticleBLL>();
            m_Kernel.Bind<IArticleImageBLL>().To<ArticleImageBLL>();
        }

        public void Dispose()
        {
            if (m_Kernel != null)
            {
                m_Kernel.Dispose();
            }
        }
    }
}
