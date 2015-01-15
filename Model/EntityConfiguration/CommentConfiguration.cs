using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    public class CommentConfiguration:EntityTypeConfiguration<CommentInfo>
    {
        public CommentConfiguration()
        {
            HasKey(p => p.CommentId);
            Property(p => p.CommentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(o => o.ArticleInfo).WithMany(o => o.CommentInfos).WillCascadeOnDelete(false);
        }
    }
}
