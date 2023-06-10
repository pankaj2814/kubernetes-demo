using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PankajAPI.Data;
using System;

namespace PankajAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PankajAPI", Version = "v1" });
            });

            var connectionString = Configuration.GetValue<string>("SQL_CONN");
            var connectionPassword = Configuration.GetValue<string>("SQL_PASS");

            connectionString = connectionString.Replace("<PASSWORD>", connectionPassword);
            Console.WriteLine("SQL_Connection_String" + connectionString);

            services.AddDbContext<EmployeeDbContext>(options => {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), ctxOptions =>
                {
                    ctxOptions.EnableRetryOnFailure();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PankajAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
