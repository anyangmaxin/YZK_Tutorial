namespace Cache_WebAPI1
{
    public class MyDbContext
    {
        public static Task<Book?> GetByIdAsync(long id)
        {
            Book? book = null;
            switch (id)
            {
                case 1:
                    book = new Book() { Id = id, Name = $"Book{id}" };
                    break;
                case 2:
                    book = new Book() { Id = id, Name = $"Book{id}" };
                    break;
                case 3:
                    book = new Book() { Id = id, Name = $"Book{id}" };
                    break;
                default:
                    book = null;
                    break;
            }
            return Task.FromResult<Book?>(book);

        }
    }
}
