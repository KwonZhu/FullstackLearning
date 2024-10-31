using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Practice5.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        // to get action name and parameters
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllType = context.Controller.GetType();

            var controllerName = controllType.Name;

            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                var actionName = controllerActionDescriptor.ActionName;
                var parameters = controllerActionDescriptor.MethodInfo.GetParameters();

                foreach (var parameter in parameters)
                {
                    // get values from context.ActionArguments
                    if (context.ActionArguments.TryGetValue(parameter.Name, out var value))
                    {
                        Console.WriteLine("Action: {0}, Parameter: {1}, Value: {2}", actionName, parameter.Name, value);
                    }
                    else
                    {
                        Console.WriteLine("Action: {0}, Parameter: {1}, Value: null", actionName, parameter.Name);
                    }
                }

            }
        }
    }
}