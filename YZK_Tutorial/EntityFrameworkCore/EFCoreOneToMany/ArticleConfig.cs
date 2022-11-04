using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreOneToMany
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //这里可以配置对应表，对应字段 相关约束等信息

            builder.Property(o => o.Title).HasMaxLength(100).IsRequired().IsUnicode();

            builder.Property(o => o.Content).IsUnicode();
       
        }
    }
}
