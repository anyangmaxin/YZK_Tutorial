using Cache_Redis.Model;

namespace Cache_Redis.Service
{
    public class BookService
    {
        public Task<Book?> GetItems(long id)
        {
            Book result;
            switch (id)
            {
                case 0:
                    result = new Book(id, $"Book={id}");
                    break;
                case 1:
                    result = new Book(id, $"Book={id}");
                    break;
                case 2:
                    result = new Book(id, $"Book={id}");
                    break;
                case 3:
                    result = new Book(id, $"Book={id}");
                    break;
                case 4:
                    result = new Book(id, $"Book={id}");
                    break;
                case 5:
                    result = new Book(id, $"Book={id}");
                    break;
                default:
                    result = null;
                    break;
            }

            return Task.FromResult(result);
        }
    }
}
