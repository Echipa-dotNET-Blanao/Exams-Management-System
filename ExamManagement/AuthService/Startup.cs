using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using AuthService.DataLayer.Management;
using AuthService.BusinessLayer.Repository;
using AuthService.BusinessLayer.Service;
using Swashbuckle.AspNetCore.Swagger;

namespace AuthService
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
            services.AddDbContext<ApplicationContext>(options => options.UseMySql("Server=golar3.go.ro;Database=FiiExam;User=fiiexam;Password=fiiexam;",
           mySqlOptions =>
           {
               mySqlOptions.ServerVersion(new Version(5, 1, 73), ServerType.MySql);
           }));
            services.AddScoped<DbContext, ApplicationContext>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthServiceImpl>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Auth", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth V1"); });
        }
    }
}
