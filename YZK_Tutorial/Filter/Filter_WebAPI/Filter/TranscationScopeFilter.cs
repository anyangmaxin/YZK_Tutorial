using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Transactions;

namespace Filter_WebAPI.Filter
{
    /// <summary>
    /// 自定义执行事务Filter
    /// </summary>
    public class TranscationScopeFilter : IAsyncActionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //throw new NotImplementedException();
            //是否包含NotTransactionalAttribute  默认为不包含   如果标注了，则不提供事务
            bool hasNotTransactionalAttribute = false;
            //判断当前 Action是否能转换成  控制器操作的描述符
            if (context.ActionDescriptor is ControllerActionDescriptor)
            {
                //获取描述
                var actionDesc = (ControllerActionDescriptor)context.ActionDescriptor;
                //通过特性来给变量赋值 如果标注了，则不提供事务
                hasNotTransactionalAttribute = actionDesc.MethodInfo.IsDefined(typeof(NotTransactionalAttribute), false);
            }

            //如果标注了，则不提供事务
            if (hasNotTransactionalAttribute)
            {
                await next();
                return;
            }
            //没有标注，提供事务
            using var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var result = await next();
            if (result.Exception == null)
            {
                txScope.Complete();
            }

        }
    }
}
