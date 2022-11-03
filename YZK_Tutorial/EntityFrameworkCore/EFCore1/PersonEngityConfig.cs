using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1
{
    public class PersonEngityConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("T_Persons");
            builder.Property(e => e.Name).HasMaxLength(30).IsRequired();
        }
    }
}
