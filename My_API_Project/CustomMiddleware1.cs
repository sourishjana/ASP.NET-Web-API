using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace My_API_Project
{
    public class CustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from CustomMiddleware1\n");
            await next(context); // passing to next middleware
            await context.Response.WriteAsync("Hello from CustomMiddleware1 after getting response from next\n");
        }
    }
}
