namespace DI_WebAPI
{
    public class TestService
    {
        private string[] files;


        public TestService()
        {
            //获取 D盘下所有exe文件  会耗时多
            this.files = Directory.GetFiles("H:\\DownLoad", "*.exe", SearchOption.AllDirectories);
        }

        public int Count()
        {
            return this.files.Length;
        }
    }
}
