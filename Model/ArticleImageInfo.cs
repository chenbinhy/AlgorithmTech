using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    public class ArticleImageInfo : DeletableObject
    {
        /// <summary>
        /// 标题
        /// </summary>
        public Guid ArticleImageId { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string Path { get; set; }
    }
}
