using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChkRepoBLL;
using ChkRepoBLL.Contracts;
using ChkRepoDAL;
using ChkRepoDAL.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChkRepo
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
            services.AddDbContext<TodoContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();
            services.AddAutoMapper();

            services.AddScoped<IToDoProcess, ToDoProcess>();
            services.AddScoped<IToDoData, ToDoData>();
            services.AddScoped<IProcessFactory, ProcessFactory>();
            services.AddScoped<IDataFactory, DataFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(cfg =>
            {
                cfg.MapRoute(
                    name: "defaultapi",
                    template: "api/{controller}/{action}/{id?}",
                    defaults: new { controller = "TestRepoService", action = "GetAll" }
                );

                cfg.MapRoute(
                    name: "defaultapp",
                    template: "{controller}/{action}/{id?}",
                    defaults: new {controller = "TestRepoApp", action = "Index"}
                );
            });
        }
    }
}
