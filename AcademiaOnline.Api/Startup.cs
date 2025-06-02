using AcademiaOnline.Infrastructure;
using AcademiaOnline.Application;
using AcademiaOnline.Infrastructure.Academia;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante;
using AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Application.Services;
using AcademiaOnline.Infrastructure.Persistence.Data.Identity;
using System;
using AcademiaOnline.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using AcademiaOnline.Infrastructure.Seguridad.TokenSeguridad;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using AcademiaOnline.Application.Common.ManejadorError;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace AcademiaOnline.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplication();
            var connectionString = _configuration.GetConnectionString("ConexionDatabase");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("La cadena de conexión 'ConexionDatabase' no está definida en appsettings.json.");
            
            services.AddInfrastructure(connectionString); // Dapper, repos
            services.AddDbContext<AcademiaOnlineBDContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.Configure<JwtSettings>(_configuration.GetSection("Jwt"));
            services.AddMediatR(typeof(RegisterEstudianteCommand).Assembly);
            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<IMateriasService, MateriasService>();
            services.AddTransient<IProgramasCreditosService, ProgramasCreditosService>();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUsuarioSesion, UsuarioSesion>();
            services.AddMediatR(typeof(AdherirEstudianteAProgramaHandler));

            var builder = services.AddIdentityCore<TbUsuario>();
            var identityBuilder = new IdentityBuilder(typeof(TbUsuario), typeof(IdentityRole), services);

            identityBuilder.AddRoles<IdentityRole>();
            identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<TbUsuario, IdentityRole>>();
            identityBuilder.AddEntityFrameworkStores<ApplicationSecurityDbContext>();
            identityBuilder.AddSignInManager<SignInManager<TbUsuario>>();
            services.TryAddSingleton<ISystemClock, SystemClock>();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy => policy.WithOrigins("http://localhost:4200")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedDatabase(app.ApplicationServices);
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }

            // Config middleware para capturar excepciones para ManejadorExcepcion
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                    if (exception is ManejadorExcepcion manejadorExcepcion)
                    {
                        context.Response.StatusCode = (int)manejadorExcepcion.Codigo;
                        await context.Response.WriteAsJsonAsync(manejadorExcepcion.ObtenerRespuesta());
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Codigo = 500,
                            Mensaje = "Error interno en el servidor.",
                            Errores = new List<string> { exception?.Message ?? "Error desconocido." }
                        });
                    }
                });
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAngular");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        static async void SeedDatabase(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            try
            {
                var context = scopedServices.GetRequiredService<ApplicationSecurityDbContext>();
                context.Database.EnsureCreated();
                await SeedData.InitializeAsync(scopedServices);
            }
            catch (Exception ex)
            {
                var logger = scopedServices.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
            }
        }
    }


}
