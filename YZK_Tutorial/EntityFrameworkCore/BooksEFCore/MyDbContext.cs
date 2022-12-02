using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BooksEFCore
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlserver("");
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //指定从哪个程序集来加载配置
            //控制台程序 可以从入口程序 获取 
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
            //从运行的当前类中获取 配置
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
