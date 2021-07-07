using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Kafka.Infra.Messaging.Consumer
{
    public class ConfluentConsumerBuilder
    {
        private readonly Dictionary<string, string> configs = new Dictionary<string, string>();

        public ConfluentConsumerBuilder AddConfig(IEnumerable<KeyValuePair<string, string>> consumerConfig)
        {
            if (consumerConfig == null)
                return this;

            foreach (var config in consumerConfig)
                AddConfig(config);

            return this;
        }

        public ConfluentConsumerBuilder AddConfig(KeyValuePair<string, string> consumerConfig)
        {
            configs[consumerConfig.Key] = consumerConfig.Value;

            return this;
        }

        public IConsumer<Ignore, string> Build(string topics)
        {
            if (configs == null || !configs.Any())
                throw new ArgumentException($"Configartion can not be null or empty");


            var consumer = new ConsumerBuilder<Ignore, string>(configs)
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .SetStatisticsHandler((_, json) => Console.WriteLine($"Statistics: {json}"))
                .Build();

            consumer.Subscribe(topics);
            return consumer;
        }

        public List<TopicPartitionOffset> BuildCommit()
        {
            if (configs == null || !configs.Any())
                throw new ArgumentException($"Configartion can not be null or empty");


            var consumer = new ConsumerBuilder<Ignore, string>(configs)
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .SetStatisticsHandler((_, json) => Console.WriteLine($"Statistics: {json}"))
                .Build();

            return consumer.Commit();
        }

        public IConsumer<Ignore, string> Build(string[] topics)
        {
            if (configs == null || !configs.Any())
                throw new ArgumentException($"Configartion can not be null or empty");


            var consumer = new ConsumerBuilder<Ignore, string>(configs)
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .SetStatisticsHandler((_, json) => Console.WriteLine($"Statistics: {json}"))
                .Build();

            consumer.Subscribe(topics);
            return consumer;
        }
    }
}
