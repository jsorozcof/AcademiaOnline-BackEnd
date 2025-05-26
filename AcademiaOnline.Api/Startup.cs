using AcademiaOnline.Infrastructure;
using AcademiaOnline.Application;
using AcademiaOnline.Infrastructure.Academia;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante;
using AcademiaOnline.Application.Features.Estudiantes.Commands.AdherirEstudianteAPrograma;
using AcademiaOnline.Application.Interfaces;
using AcademiaOnline.Application.Services;

namespace AcademiaOnline.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<RegisterEstudianteCommand>());

            services.AddApplication();     // CQRS, Validadores, MediatR
            services.AddInfrastructure(Configuration.GetConnectionString("ConexionDatabase")); // Dapper, repos
            services.AddDbContext<AcademiaOnlineBDContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConexionDatabase"));
            });

            services.AddMediatR(typeof(RegisterEstudianteCommand).Assembly);
            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<IMateriasService, MateriasService>();
            services.AddTransient<IProgramasCreditosService, ProgramasCreditosService>();
            services.AddMediatR(typeof(AdherirEstudianteAProgramaHandler));

            //services.AddAutoMapper(typeof(Consulta.Ejecuta));

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
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAngular");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
