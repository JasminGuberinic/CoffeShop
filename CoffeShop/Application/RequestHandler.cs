using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class RequestHandler
    {
        public static async Task<IActionResult> HandleCommand<T>(
            T request, Func<T, Task> handler)
        {
            try
            {
                await handler(request);
                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new
                {
                    error = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }
    }
}
