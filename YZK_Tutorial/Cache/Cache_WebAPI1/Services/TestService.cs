namespace Cache_WebAPI1.Services
{
    public class TestService
    {
        public readonly ILogger<TestService> Logger;
        public TestService(ILogger<TestService> logger)
        {
            Logger = logger;
        }

        public IEnumerable<int> GetItems()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            Logger.LogInformation("执行到内部");
            yield return 5;
            yield return 6;
        }
    }
}
