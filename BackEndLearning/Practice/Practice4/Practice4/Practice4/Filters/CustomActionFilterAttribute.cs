using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Practice4.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string fullName = context.ActionDescriptor.DisplayName;
            // Splitting fullName based on the . and ()
            var parts = fullName.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string controllerName = parts[parts.Length - 2]; // This will give "UserController"
            string actionName = parts[parts.Length - 1].Split(' ')[0]; // This will give "GetUserInfoById"
            Console.WriteLine($"Controller Name: {controllerName}, Action Name: {actionName}");

            // Obtain the action parameters (name-value pairs of parameters) and serialize them to JSON format
            var actionParameters = context.ActionArguments;
            string parametersJson = JsonSerializer.Serialize(actionParameters);
            Console.WriteLine($"Parameters: {parametersJson}");

            // Call the base implementation (optional, depending on if you need additional base logic).
            base.OnActionExecuting(context);
        }
    }
}
