using AutoMapper;
using DanskeBank.BL.Manager;
using DanskeBank.DAL.Context;
using DanskeBank.DAL.Repository;
using DanskeBank.DAL.Utlity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeBank.API
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
            //enable the sql server storagr option
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction:sqlOption=>
                {//enable the retry polocy
                    sqlOption.EnableRetryOnFailure(
                        maxRetryCount:10,
                        maxRetryDelay:TimeSpan.FromSeconds(5),
                        errorNumbersToAdd:null
                        );
                }
                ));
            //business logic service  added
            services.AddScoped<ITaxManager, TaxManager>();
            // Data access layer service added
            services.AddScoped<IRepository, Repository>();
            // automapper service added
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddControllers()
                .AddNewtonsoftJson(options=>options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            //enable the swagger for API
            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Danske Bank API", Version = "v1" }); });
            services.AddSwaggerGenNewtonsoftSupport();
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
            app.UseSwagger();
            //enable the swagger endpoint
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Danske Bank API V1"); });
        }
    }
}
