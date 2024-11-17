using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;

public class UniqueUserFilter : IActionFilter
{
    private static HashSet<string> uniqueUsers = new HashSet<string>();

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var userIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();

        if (userIp != null && uniqueUsers.Add(userIp))
        {
            using (StreamWriter writer = new StreamWriter("Logs/UniqueUsers.txt", false))
            {
                writer.WriteLine($"Unique users count: {uniqueUsers.Count}");
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
