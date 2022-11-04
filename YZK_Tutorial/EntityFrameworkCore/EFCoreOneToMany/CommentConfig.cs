using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreOneToMany
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //这里可以配置对应表，对应字段 相关约束等信息
            //一篇文章里面可以对应多个评论
            builder.HasOne<Article>(c => c.Article).WithMany(o => o.Comments).IsRequired();

            builder.Property(o => o.Message).IsRequired().IsUnicode(true);
        }
    }
}
