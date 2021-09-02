using EasyException.Abstractions;
using EasyException.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EasyException.Middleware
{
    public class EasyExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        private readonly IErrorHandlingService _errorService;

        public EasyExceptionHandlingMiddleware(RequestDelegate requestDelegate, IErrorHandlingService errorService)
        {
            this.requestDelegate = requestDelegate;
            _errorService = errorService;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                var error = await _errorService.HandleException(ex);
                
                await HandleException(context, error);
            }
        }
        private static Task HandleException(HttpContext context, ErrorResponse error)
        {
            var errorMessage = JsonConvert.SerializeObject(error);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(errorMessage);
        }
    }
}
