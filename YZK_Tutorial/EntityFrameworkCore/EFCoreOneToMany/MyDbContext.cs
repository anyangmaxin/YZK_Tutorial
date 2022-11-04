using Microsoft.EntityFrameworkCore;



namespace EFCoreOneToMany
{
    public class MyDbContext : DbContext
    {

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //配置数据库连接
            string connStr = "Server=.;DataBase=TrainDB;Trusted_Connection=True;MultipleActiveResultSets=True;";
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //指示配置类在此程序集下
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
