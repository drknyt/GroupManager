using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CRUD.UserManagment.API.Helper
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostingEnvironment environment;

        public ErrorHandlingMiddleware(RequestDelegate next , IHostingEnvironment environment)
        {
            this.next = next;
            this.environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new { error = exception.Message , firedOn = DateTime.Now , stackTrace = exception.StackTrace});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var logPath = System.IO.Path.GetFullPath("ErrorLog.txt");
            
            var logWriter = new System.IO.StreamWriter(logPath , true);
            logWriter.WriteLine(result);
            logWriter.WriteLine("============");
            logWriter.Dispose();
            
            return context.Response.WriteAsync(result);
        }
    }
}
