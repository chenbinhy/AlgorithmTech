using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    /// <summary>
    /// 评论信息
    /// </summary>
    public class CommentInfo : DeletableObject
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid CommentId { get; set; }

        /// <summary>
        /// 评论信息
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime CommitTime { get; set; }

        /// <summary>
        /// 文章Id
        /// </summary>
        public Guid ArticleId { get; set; }

        /// <summary>
        /// 文章实体
        /// </summary>
        public ArticleInfo ArticleInfo { get; set; }
    }
}
