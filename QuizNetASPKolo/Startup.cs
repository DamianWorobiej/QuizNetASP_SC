using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuizNetASPKolo.BusinessLogic;
using QuizNetASPKolo.BusinessLogic.Interfaces;
using QuizNetASPKolo.BusinessLogic.Mapper;
using QuizNetDataAccess;
using AutoMapper;
using QuizNetASPKolo.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace QuizNetASPKolo
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
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<EFDbContext>(options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=QuizNetASPKolo;Trusted_Connection=True;"));
            //services.AddDbContext<EFDbContext>(options => options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=QuizNetASPKolo;Trusted_Connection=True;"));
            services.AddScoped<IQuestionRepository, EFQuestionRepository>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
