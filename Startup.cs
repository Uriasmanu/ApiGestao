using Microsoft.EntityFrameworkCore;
using ApiGestao.Banco;

namespace ApiGestao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configuração dos serviços
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do CORS
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Configuração do banco de dados
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));

            // Outros serviços
            services.AddControllers();
        }

        // Configuração do pipeline de requisição HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy"); // Aplica a política de CORS

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
