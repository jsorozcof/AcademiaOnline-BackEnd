using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaOnline.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(cfg =>
            //    cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceExtensions).Assembly));

            services.AddValidatorsFromAssembly(typeof(ApplicationServiceExtensions).Assembly);
            return services;
        }
    }
}
