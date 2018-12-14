using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Core.Interfaces;
using ExamManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;

namespace ExamManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //TODO: https://www.c-sharpcorner.com/article/onion-architecture-in-asp-net-core-mvc/
        //TODO: Our architecture is 3 layered when Onion is at leaste 4 layered.
        //TODO: Maybe we should reconsider and add another layer
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseMySql("Server=golar3.go.ro;Database=FiiExam;User=fiiexam;Password=fiiexam;",
                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(5, 1, 73), ServerType.MySql);
                    }));
            services.AddScoped<DbContext, AppDbContext>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //TODO: for the moment we will stick with one version, I will investigate how to split every controller
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ExamManagement", Version = "v1" });
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExamManagement V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
