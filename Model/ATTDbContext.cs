using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.AlgorithmTech.Model
{
    public class ATTDbContext:DbContext
    {
        public ATTDbContext()
            : base("ATT")
        {
            Database.SetInitializer<ATTDbContext>(null);
        }

        public DbSet<TagInfo> Tags { get; set; }
        public DbSet<CommentInfo> Comments { get; set; }
        public DbSet<ArticleInfo> Articles { get; set; }
        public DbSet<ArticleImageInfo> ArticleImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new ArticleImageConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
