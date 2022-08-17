using CasaPopular.Application.Applications;
using CasaPopular.Domain.Interfaces.Applications;
using CasaPopular.Domain.Interfaces.Repositories;
using CasaPopular.Domain.Interfaces.Services;
using CasaPopular.Infra.Data.Context;
using CasaPopular.Infra.Data.Repositories;
using CasaPopular.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CasaPopular.API
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
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<CasaPopularContext>(options =>
                {
                    options.UseSqlServer(Configuration["ConnectionString"],
                        sqlOptions => sqlOptions.MigrationsAssembly("CasaPopular.Infra.Data"));
                },
                ServiceLifetime.Scoped
            );            
            services.AddScoped<IFamiliaApplication, FamiliaApplication>();
            services.AddScoped<IFamiliaService, FamiliaService>();
            services.AddScoped<IFamiliaRepository, FamiliaRepository>();
            services.AddScoped<IPontuacaoApplication, PontuacaoApplication>();
            services.AddScoped<IPontuacaoService, PontuacaoService>();
            services.AddScoped<IPontuacaoRepository, PontuacaoRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CasaPopular.API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CasaPopular.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
