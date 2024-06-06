﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace FlightProject.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
      
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
         
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Hatası",
                    Title = "Bağlantı Hatası",
                    Detail = "Server'a bağlantı sağlanamadı"

                };

                string json = JsonSerializer.Serialize(problem);
                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
                
            }
        }
    }
}
