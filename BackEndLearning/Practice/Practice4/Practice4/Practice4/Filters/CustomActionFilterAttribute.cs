using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Practice4.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string fullName = context.ActionDescriptor.DisplayName;
            var actionName = fullName.Split('.').Last().Split(' ')[0];
            Console.WriteLine($"Action Name: {actionName}");

            // Obtain the action parameters (name-value pairs of parameters) and serialize them to JSON format
            var actionParameters = context.ActionArguments;
            string parametersJson = JsonSerializer.Serialize(actionParameters);
            Console.WriteLine($"Parameters: {parametersJson}");

            // Call the base implementation (optional, depending on if you need additional base logic).
            base.OnActionExecuting(context);
        }
    }
}
