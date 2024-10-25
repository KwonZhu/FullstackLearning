using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practice4.Controllers;
using Practice4.ViewModels;
using System;
using System.Collections.Generic;


namespace Practice4.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Check if the exception is a NotFoundException
            if (context.Exception is NotFoundException notFoundException)
            {
                // Return a 404 Not Found result with a failure message
                context.Result = new JsonResult(new CommonResult<object>
                {
                    Success = false,
                    Message = notFoundException.Message,
                    Error = "Resource not found"
                })
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                // Handle any other unexpected exceptions
                context.Result = new JsonResult(new CommonResult<object>
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Error = context.Exception.Message
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
//public void OnException(ExceptionContext context)
//{
//    // Create a standardized error response using CommonResult<T>
//    var errorResponse = new CommonResult<object>
//    {
//        Success = false,
//        Message = "An error occurred while processing your request.",
//        Error = context.Exception.Message,
//        Data = null
//    };

//    // Set the response result and status code
//    context.Result = new JsonResult(errorResponse)
//    {
//        StatusCode = 500
//    };

//    // Mark the exception as handled
//    context.ExceptionHandled = true;
//}
