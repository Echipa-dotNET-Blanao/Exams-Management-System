using System;
using ExamManagement.Core.Interfaces.Repositories;
using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Infrastructure.Data;
using ExamManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseMySql(
                "Server=golar3.go.ro;Database=FiiExam;User=fiiexam;Password=fiiexam;",
                mySqlOptions => { mySqlOptions.ServerVersion(new Version(5, 1, 73), ServerType.MySql); }));
            services.AddScoped<DbContext, AppDbContext>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IPresenceService, PresenceService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "ExamManagement", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExamManagement V1"); });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}