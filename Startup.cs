using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IrsMonkeyApi.Models.DAL;
using IrsMonkeyApi.Models.DB;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AutoMapper;

namespace IrsMonkeyApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options => 
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddDbContext<IRSMonkeyContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("IrsMonkeyDatabase")));
            services.AddScoped<IMemberLoginDal, MemberLoginDal>();
            services.AddScoped<IMemberDal, MemberDal>();
            services.AddScoped<IFormDal, FormDal>();
            services.AddScoped<IResolutionDal, ResolutionDal>();
            services.AddScoped<IGeoLocationDal, GeoLocationDal>();
            services.AddScoped<IFormSubmittedDal, FormSubmittedDal>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
