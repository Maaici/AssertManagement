using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Gemini.Core.Api
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region 配置swagger

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "api文档",
                    TermsOfService = new Uri("https://me.csdn.net/maaici")
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Gemini.Api.xml");
                var xmlPathByModel = Path.Combine(basePath, "Gemini.Api.xml");
                options.IncludeXmlComments(xmlPathByModel);
                //true表示生成控制器描述，包含true的IncludeXmlComments重载应放在最后，或者两句都使用true
                options.IncludeXmlComments(xmlPath, true);
            });

            #endregion
        }

        /// <summary>
        /// 配置服务（中间件）
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(action =>
            {
                action.ShowExtensions();
                action.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
