// See https://aka.ms/new-console-template for more information
using EFCore1;

Console.WriteLine("Hello, World!");
//{
//    Console.WriteLine("插入数据");
//    using (var dbctx = new TestDbContext())
//    {
//        Book book = new Book()
//        {
//            Price = 100,
//            PubTime = DateTime.Now.AddMonths(-3),
//            Title = "测试"
//        };

//        dbctx.Books.Add(book);
//        //推荐使用异步方法
//        await dbctx.SaveChangesAsync();

//    }
//    Console.WriteLine("插入数据***************");
//}

//{
//    Console.WriteLine("更新数据");
//    using (var dbctx = new TestDbContext())
//    {
//        var model=dbctx.Books.OrderByDescending(o => o.Id).FirstOrDefault();
//        model.Price += 20;

//        //推荐使用异步方法
//        await dbctx.SaveChangesAsync();

//    }
//    Console.WriteLine("更新数据***************");
//}



{
    Console.WriteLine("删除数据");
    using (var dbctx = new TestDbContext())
    {
        var model = dbctx.Books.OrderByDescending(o => o.Id).FirstOrDefault();
        // model.Price += 20;
        dbctx.Books.Remove(model);
        //推荐使用异步方法
        await dbctx.SaveChangesAsync();

    }
    Console.WriteLine("删除数据***************");
}


{
    Console.WriteLine("查询数据");
    using (var dbctx = new TestDbContext())
    {
        var models = dbctx.Books.ToList();
        foreach (var item in models)
        {
            Console.WriteLine($"{item.Id}-{item.Title}-{item.Price}");
        }

    }
    Console.WriteLine("查询数据***************");
}
