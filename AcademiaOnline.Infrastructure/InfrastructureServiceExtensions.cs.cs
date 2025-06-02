using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Domain.Entities;
using AcademiaOnline.Infrastructure.Persistence.Data.Identity;
using AcademiaOnline.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            services.AddScoped<IMateriasRepository, MateriasRepository>();
            services.AddScoped<IProgramasCreditosRepository, ProgramasCreditosRepository>();

            services.AddDbContext<ApplicationSecurityDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddIdentity<TbUsuario, ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationSecurityDbContext>()
                    .AddDefaultTokenProviders();
            return services;
        }
    }
}
