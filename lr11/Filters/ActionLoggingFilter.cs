using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Threading.Tasks;

public class ActionLoggingFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        using (StreamWriter writer = new StreamWriter("Logs/ActionLog.txt", true))
        {
            writer.WriteLine($"Method: {actionName}, Time: {currentTime}");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
