using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRLearn.Business;
using SignalRLearn.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLearn
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
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin => true)
            ));

            services.AddTransient<MyBusiness>();
            services.AddRazorPages();
            services.AddControllers();

            //SignalR kullanaca��m� s�yledim 
            services.AddSignalR();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Uygulamada myhub'a bir istek gelirse MyHub taraf�ndan bu istek kar��lanacak.
                endpoints.MapHub<MyHub>("/myhub");
                endpoints.MapHub<MessageHub>("/messagehub");
                endpoints.MapControllers();
            });
        }
    }
}
