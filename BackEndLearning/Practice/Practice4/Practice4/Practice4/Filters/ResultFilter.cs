using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice4.Models;
using Practice4.ViewModels;

namespace Practice4.Filters
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value is CommonResult<User> result)
            {
                // Check if the result contains an error message
                if (!string.IsNullOrEmpty(result.Error))
                {
                    // Skip adding the timestamp since there's an error
                    return;
                }

                // add timestamp
                result.Timestamp = DateTime.UtcNow.ToString();
            }
        }
    }
}
