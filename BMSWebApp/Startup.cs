using EmployeeRequest.Models;
using FileServerManagementWepApp.Models;
using GuardWebApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using LoggerWebApp.Models;
using TechnicalInfoWebApp.Models;
using ProjectManagementWebApp.Models;

namespace BMSWebApp
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
            services.AddDbContext<EmployeeRequestDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeRequestCS")));
            services.AddDbContext<FileServerDBContext>(options =>{options.UseSqlServer(Configuration.GetConnectionString("FileServerCS"));});
            services.AddDbContext<GuardianDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GuardianCS")));
            services.AddDbContext<ILogDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ILogCS")));
            services.AddDbContext<TechnicalInfoDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TechnicalInfoCS")));
            services.AddDbContext<ProjectManagementDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProjectManagementCS")));

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()));

            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSession();

            //app.UseMiddleware<AuthenticationMiddleware>();

            app.UseCors("AllowAllHeaders");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }

        public class TimeSpanToStringConverter : JsonConverter<TimeSpan>
        {
            public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                return TimeSpan.Parse(value);
            }

            public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString());
            }
        }
    }
}
