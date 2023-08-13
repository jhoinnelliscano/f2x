using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using F2x.EntityDomain.Objects;

namespace F2x.API.Config
{
    public static class GlobalExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                    var ex = errorFeature.Error;
                    var errorMessage = ex.InnerException != null ? ex.InnerException.Message + "/" + ex.Message : ex.Message;

                    object detail;
                    detail = new ServiceResponseObject<ErrorObject>()
                    {
                        StatusCode = 500,
                        Message = "An error has occurred",
                        Result = new ErrorObject() 
                        {
                            ErrorMessage = "Internal server error : " + errorMessage
                        }
                    };
                    var response = Newtonsoft.Json.JsonConvert.SerializeObject(detail, Newtonsoft.Json.Formatting.Indented);

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var jsonResponse = JsonConvert.SerializeObject(detail, Newtonsoft.Json.Formatting.Indented);
                        await context.Response.WriteAsync(jsonResponse);
                    }
                });
            });
        }
    }
}
