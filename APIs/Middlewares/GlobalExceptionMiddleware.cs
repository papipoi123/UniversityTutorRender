using Applications.Commons;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace APIs.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                // handling error 
                Response response = new Response((HttpStatusCode)context.Response.StatusCode, ex.Message);
#if DEBUG
                if (Debugger.IsAttached)
                {
                    response.Result = ex;
                }
#endif       
                var options = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, options));
            }
        }
    }
}
