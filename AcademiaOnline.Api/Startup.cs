using AcademiaOnline.Infrastructure;
using AcademiaOnline.Application;
using AcademiaOnline.Infrastructure.Academia;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AcademiaOnline.Application.Features.Estudiantes.Commands.RegisterEstudiante;

namespace AcademiaOnline.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());
            
            //Agregar capas personalizadas (Application, Infrastructure)
            services.AddApplication();     // CQRS, Validadores, MediatR
            services.AddInfrastructure(Configuration.GetConnectionString("ConexionDatabase")); // Dapper, repos
            services.AddDbContext<AcademiaOnlineBDContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConexionDatabase"));
            });

            services.AddMediatR(typeof(RegisterEstudianteCommand).Assembly);
            //services.AddAutoMapper(typeof(Consulta.Ejecuta));

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
