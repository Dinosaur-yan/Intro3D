using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Intro3D.Api.Extensions
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Intro3D.Api", Version = "v1" });

                var xmls = new string[] { "Intro3D.Api.xml" };
                foreach (var xml in xmls)
                {
                    var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "Swagger", xml);
                    options.IncludeXmlComments(xmlPath, true);
                }

                var security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                };
                options.AddSecurityRequirement(security);
                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "Format: {token}",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Scheme = "Bearer",
                //    Type = SecuritySchemeType.Http,
                //    BearerFormat = "JWT"
                //});
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Intro3D.Api v1");

                //http://localhost:****/{RoutePrefix}/index.html
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
