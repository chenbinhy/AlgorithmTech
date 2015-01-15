using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    /// <summary>
    /// 标签信息
    /// </summary>
    public class TagInfo : DeletableObject
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid TagId { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文章列表
        /// </summary>
        public List<ArticleInfo> ArticleInfos { get; set; }
    }
}
