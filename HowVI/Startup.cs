using Entities.Contracts;
using HowVI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Repositories;

namespace HowVI
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
            var connectionString = Context.Conector();

            services.AddDbContext<Context>(option => 
            {
                option.UseInMemoryDatabase(connectionString);
                option.EnableSensitiveDataLogging();
            });

            services.AddScoped<IAtividadeRepository, AtividadeRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContatoClienteRepository, ContatoClienteRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<IService, Service>();

            services.AddCors();
            
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IService service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            service.InicializaBanco();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HowVI");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}


