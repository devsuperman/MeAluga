using MeAluga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json;

namespace BackEnd
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
            // services.AddEntityFrameworkNpgsql()
            //     .AddDbContext<Contexto>(options => 
            //         options.UseNpgsql(Configuration.GetConnectionString("ElephantSQL")));

            services.AddResponseCompression();
            services.AddDbContext<Contexto>(options => 
                    options.UseSqlite(Configuration.GetConnectionString("MeAlugaDB")));

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(a => a.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);       

            services.AddCors();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            var culturaBrasileira = new RequestLocalizationOptions { DefaultRequestCulture = new RequestCulture("pt-BR") };
            app.UseRequestLocalization(culturaBrasileira);
            
            app.UseCors(a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}
