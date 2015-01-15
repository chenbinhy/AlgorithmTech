using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    public class ArticleImageConfiguration:EntityTypeConfiguration<ArticleImageInfo>
    {
        public ArticleImageConfiguration()
        {
            HasKey(p => p.ArticleImageId);
            Property(p => p.ArticleImageId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
