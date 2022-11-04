using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreOneToMany
{
    public class CommentConfig : IEntityTypeConfiguration<CommentConfig>
    {
        public void Configure(EntityTypeBuilder<CommentConfig> builder)
        {
            //这里可以配置对应表，对应字段 相关约束等信息
        }
    }
}
