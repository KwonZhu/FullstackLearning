﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Practice5.ViewModels;

namespace Practice5.Filters
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {

            if (context.Result is not CommonResult)
            {

                if (context.Result is ObjectResult objectResult)
                {
                    if (objectResult == null)
                        return;

                    if (objectResult.Value == null)
                    {
                        var isSuccess = context.HttpContext.Response.StatusCode == 200 || context.HttpContext.Response.StatusCode == 201;
                        context.Result = new JsonResult(new CommonResult() { Success = isSuccess });
                        return;
                    }

                    var resultType = objectResult.Value.GetType();
                    if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() != typeof(CommonResult<>))
                    {
                        var comResult = new CommonResult<object>()
                        {
                            Success = true,
                            Result = objectResult.Value
                        };

                        context.Result = new JsonResult(comResult);
                    }

                }
            }
        }
    }
}
