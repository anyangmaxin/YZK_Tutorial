using Filter_WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Filter_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Demo2Controller : ControllerBase
    {
        private readonly MyDbContext myDbContext;

        public Demo2Controller(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        [HttpGet]
        public Book GetBook(long id)
        {
            var model = myDbContext.Books.FirstOrDefault(x => x.Id == id);
            return model;
        }


        [HttpPost]
        public async Task<string> AddBook()
        {
            myDbContext.Books.Add(new Model.Book { Title = "我最棒" + DateTime.Now });
            await myDbContext.SaveChangesAsync();
            return "OK";
        }


        /// <summary>
        /// 测试部分成功部分失败
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> AddBookPerson()
        {

            myDbContext.Books.Add(new Model.Book { Title = "我最棒" + DateTime.Now });
            await myDbContext.SaveChangesAsync();
            myDbContext.Persons.Add(new Model.Person { Id = 1, Name = "姓名" + DateTime.Now, Age = 18 + Random.Shared.Next(1, 10) });
            await myDbContext.SaveChangesAsync();
            return "OK";
        }


        /// <summary>
        /// 同一事务实现要么成功，要么失败
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> AddBookPerson2()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                myDbContext.Books.Add(new Model.Book { Title = "我最棒" + DateTime.Now });
                await myDbContext.SaveChangesAsync();
                myDbContext.Persons.Add(new Model.Person { Id = 1, Name = "姓名" + DateTime.Now, Age = 18 + Random.Shared.Next(1, 10) });
                await myDbContext.SaveChangesAsync();
                return "OK";
            }
        }

    }
}
