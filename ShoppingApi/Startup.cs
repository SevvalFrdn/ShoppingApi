using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShoppingApi.Entities;
using ShoppingApi.Services;
using ShoppingRedis.Configurations;
using ShoppingRedis.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi
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
            services.Configure<ShoppingDatabaseSettings>(Configuration.GetSection(nameof(ShoppingDatabaseSettings)));

            services.AddSingleton<IShoppingDatabaseSettings>(sp =>  sp.GetRequiredService<IOptions<ShoppingDatabaseSettings>>().Value);

            services.AddSingleton<CategoryServices>();
            services.AddSingleton<ProductServices>();
            services.AddControllers();
            //services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
            //services.AddSingleton<ICacheServices, RedisCacheManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
