using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Practice5.ViewModels;

namespace Practice5.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            CommonResult commonResult = new CommonResult();
            commonResult.Success = false;
            commonResult.Message = "An error occurred while processing your request.";

#if DEBUG
            commonResult.Errors.Add(context.Exception.Message);
#endif

            // Set the returned status code and returned content
            context.Result = new JsonResult(commonResult)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
