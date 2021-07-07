using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Meetup.Kafka.Application.Extensions
{
    public static class ApplicationCollectionExtension
    {
        public static Assembly Assembly => typeof(ApplicationCollectionExtension).Assembly;

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                    .AddMediatR(Assembly);
        }
    }
}
