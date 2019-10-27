using Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExceptionHandlerMiddleware.API
{
    public static class CustomExceptionExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {

                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    CustomException exception = (CustomException)contextFeature.Error;
                    if (exception.Code == "500")
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    if (contextFeature != null)
                    {
                        
                        await context.Response.WriteAsync(new OperationResult()
                        {
                            IsSuccessful = false,
                            ReturnCode = Convert.ToInt32(exception.Code),
                            ReturnMessage = contextFeature.Error.Message

                        }.ToString());
                    }
                });
            });
        }
    }
}
