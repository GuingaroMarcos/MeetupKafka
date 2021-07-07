using Meetup.Kafka.Application.Extensions;
using Meetup.Kafka.Application.Request;
using Meetup.Kafka.Infra.Extensions;
using Meetup.Kafka.Infra.Messaging.Consumer;
using Meetup.Kafka.Infra.Messaging.Producer;
using Meetup.Kafka.Web.HostedService.Consumer;
using Meetup.Kafka.Web.Hubs;
using Meetup.Kafka.Web.Integration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Meetup.Kafka.Web
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
            services.AddControllersWithViews();

            services.AddSignalR();

            services.AddHostedService<ConsumerBase>();
            services.AddSingleton<IProducer<ProductRequest>, ProductProducer>();
            services.AddSingleton<IConsumer, NotificationConsumer>();
            services.AddInfra(Configuration).AddApplication(Configuration);
            services.AddControllers().AddNewtonsoftJson();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapHub<NotificationHub>("/notificationHub");
            });

            app.UseSpa(spa =>
            {
                spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
