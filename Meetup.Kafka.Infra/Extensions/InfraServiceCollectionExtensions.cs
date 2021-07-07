using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Meetup.Kafka.Infra.Extensions
{
    public static class InfraServiceCollectionExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = configuration.GetSection("ProducerConfig").GetSection("BootstrapServers").Value,
                MessageTimeoutMs = configuration.GetSection("ProducerConfig").GetSection("MessageTimeoutMs").Value is not null ?
                int.Parse(configuration.GetSection("ProducerConfig").GetSection("MessageTimeoutMs").Value) : throw new Exception("Parameter cannot be null MessageTimeoutMs"),
                MessageSendMaxRetries = configuration.GetSection("ProducerConfig").GetSection("MessageSendMaxRetries").Value is not null ?
                int.Parse(configuration.GetSection("ProducerConfig").GetSection("MessageSendMaxRetries").Value) : throw new Exception("Parameter cannot be null MessageSendMaxRetries"),
            };
            var ConsumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration.GetSection("ConsumerConfig").GetSection("BootstrapServers").Value,
                GroupId = configuration.GetSection("ConsumerConfig").GetSection("GroupId").Value
            };
            return services.AddSingleton(producerConfig).AddSingleton(ConsumerConfig);
        }
    }
}
