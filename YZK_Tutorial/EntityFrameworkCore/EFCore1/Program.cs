// See https://aka.ms/new-console-template for more information
using EFCore1;

Console.WriteLine("Hello, World!");
Console.WriteLine("插入数据");
using (var dbctx = new TestDbContext())
{
    Book book = new Book()
    {
        Price = 100,
        PubTime = DateTime.Now.AddMonths(-3),
        Title = "测试"
    };

    dbctx.Books.Add(book);
    //推荐使用异步方法
    await dbctx.SaveChangesAsync();
}