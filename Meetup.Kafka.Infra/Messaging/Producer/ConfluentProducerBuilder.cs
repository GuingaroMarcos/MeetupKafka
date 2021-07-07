using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetup.Kafka.Infra.Messaging.Producer
{
    public class ConfluentProducerBuilder
    {
        private Dictionary<string, string> configs = new Dictionary<string, string>();

        public ConfluentProducerBuilder AddConfig(IEnumerable<KeyValuePair<string, string>> producerConfig)
        {
            if (producerConfig == null)
                return this;

            foreach (var config in producerConfig)
                AddConfig(config);

            return this;
        }

        public ConfluentProducerBuilder AddConfig(KeyValuePair<string, string> producerConfig)
        {
            configs[producerConfig.Key] = producerConfig.Value;

            return this;
        }

        public IProducer<string, string> Build()
        {
            if (configs == null || !configs.Any())
                throw new Exception($"Configartion can not be null or empty");

            var producer = new ProducerBuilder<string, string>(configs)
                .Build();

            return producer;
        }
    }
}
