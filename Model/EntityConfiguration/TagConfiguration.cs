using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    public class TagConfiguration:EntityTypeConfiguration<TagInfo>
    {
        public TagConfiguration()
        {
            HasKey(p => p.TagId);
            Property(p => p.TagId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}
