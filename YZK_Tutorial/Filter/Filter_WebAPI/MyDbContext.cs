using Filter_WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Filter_WebAPI
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }


    }
}
