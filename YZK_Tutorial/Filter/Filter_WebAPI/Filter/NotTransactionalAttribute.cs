namespace Filter_WebAPI.Filter
{
    /// <summary>
    /// 自定义特性  标记上则不执行事务
    /// </summary>
    internal class NotTransactionalAttribute : Attribute
    {
    }
}