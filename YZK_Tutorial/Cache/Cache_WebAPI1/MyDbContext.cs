namespace Cache_WebAPI1
{
    public class MyDbContext
    {
        public static Book? GetByIdAsync(long id)
        {
            switch (id)
            {
                case 1:
                    return new Book() { Id = id, Name = $"Book{id}" };
                case 2:
                    return new Book() { Id = id, Name = $"Book{id}" };
                case 3:
                    return new Book() { Id = id, Name = $"Book{id}" };
                default:
                    return null;
            }

        }
    }
}
