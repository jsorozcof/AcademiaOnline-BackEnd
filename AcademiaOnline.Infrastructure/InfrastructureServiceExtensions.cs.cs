using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Infrastructure.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace AcademiaOnline.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>(); // Si lo estás usando

            return services;
        }
    }
}
