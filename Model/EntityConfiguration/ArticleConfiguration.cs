using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    public class ArticleConfiguration:EntityTypeConfiguration<ArticleInfo>
    {
        public ArticleConfiguration()
        {
            HasKey(p => p.ArticleId);
            Property(p => p.ArticleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Title).HasMaxLength(100);
            HasRequired(o => o.TagInfo).WithMany(o => o.ArticleInfos).WillCascadeOnDelete(false);
        }
    }
}
