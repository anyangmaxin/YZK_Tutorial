using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    public class BookEntityConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("T_Books");
            //设置Title列最长50，而且不可为空
            builder.Property(e => e.Title).HasMaxLength(50).IsRequired();
        }
    }
}
