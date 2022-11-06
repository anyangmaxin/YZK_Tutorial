// See https://aka.ms/new-console-template for more information
using EFCoreOneToMany;

Console.WriteLine("Hello, World!");

IEnumerable<Article> articles;
using (MyDbContext db = new MyDbContext())
{
    articles = db.Articles.Take(20).ToList();
}

foreach (Article article in articles)
{
    Console.WriteLine($"{article.Id}-{article.Title}-{article.Content}");
}