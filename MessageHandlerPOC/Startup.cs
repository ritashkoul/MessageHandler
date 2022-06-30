using MessageHandlerPOC.Handlers;
using MessageHandlerPOC.Interfaces;
using MessageHandlerPOC.Payloads;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageHandlerPOC
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
            services.AddMessageHandlers();
            services.AddTransient<IBL, BL>();
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

    public static class MessageHandlerServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageHandlers(this IServiceCollection services)
        {
            services.RegisterHandler<DummyMessageTwo, DummyHandlerTwo>();
            services.RegisterHandler<DummyMessageOne, DummyHandlerOne>();

            services.AddSingleton<IMessageHandlerFactory>(serviceProvider =>
            {
                var factory = new MessageHandlerFactory();
                factory.RegisterHandler(MessageType.DummyMessageOne.ToString(),
                    serviceProvider.GetService<MessageHandlerWrapper<DummyMessageOne>>);
                factory.RegisterHandler(MessageType.DummyMessageTwo.ToString(),
                    serviceProvider.GetService<MessageHandlerWrapper<DummyMessageTwo>>);
                return factory;
            });
            services.AddSingleton<IMessageHandler, MessageHandler>();
            return services;
        }

        private static void RegisterHandler<TContent, THandler>(this IServiceCollection services)
            where TContent : class
            where THandler : class, IMessageHandler<TContent>
        {
            services.AddSingleton<THandler>();
            services.AddSingleton(serviceProvider =>
                new MessageHandlerWrapper<TContent>(serviceProvider.GetService<THandler>()));
        }
    }
}
