using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    [Table("Articles")]
    public class ArticleInfo:DeletableObject
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid ArticleId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        [ForeignKey("ArticleImageInfo")]
        public Guid TitleImageId { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime CommiteTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 所属标签
        /// </summary>
        public Guid TagId { get; set; }

        /// <summary>
        /// 标签信息
        /// </summary>
        public TagInfo TagInfo { get; set; }

        /// <summary>
        /// 评论信息
        /// </summary>
        public List<CommentInfo> CommentInfos { get; set; }

        /// <summary>
        /// 文章标题图片
        /// </summary>
        public ArticleImageInfo ArticleImageInfo { get; set; }
    }
}
