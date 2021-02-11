using System;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using WebTransaction.DataAccess;
using WebTransaction.DataAccess.Interfaces;
using WebTransaction.Handlers.Helpers;
using WebTransaction.Handlers.Interfaces;
using WebTransaction.Handlers.Parsers;

namespace WebTransaction
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebTransaction", Version = "v1" });
            });

            services.AddDbContext<DataContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddMediatR(GetMediatrAssembliesToScan());
            services.AddAutoMapper(cfg => cfg.AddProfile(typeof(MapperConfiguration)));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IParser, Parser>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebTransaction v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private Type[] GetMediatrAssembliesToScan()
        {
            var nameSpace = "WebTransaction.Handlers";
            var assemblies = Assembly.Load(nameSpace)
                .GetTypes()
                .Where(p => p.Namespace != null)
                .Where(p => p.Namespace.Contains(nameSpace, StringComparison.InvariantCultureIgnoreCase))
                .ToArray();

            return assemblies;
        }
    }
}