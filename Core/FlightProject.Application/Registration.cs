using FlightProject.Application.Exceptions;

using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FlightProject.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
    
            services.AddTransient<ExceptionMiddleware>();

            services.AddControllers()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Assembly>());        

        }

     
    }
}
