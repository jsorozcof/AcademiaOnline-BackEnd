using AcademiaOnline.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

            services.AddDbContext<AcademiaDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConexionDatabase"));
            });

            //services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
            //services.AddAutoMapper(typeof(Consulta.Ejecuta));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
