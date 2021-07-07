using Confluent.Kafka;
using Meetup.Kafka.Domain.Confgs;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Meetup.Kafka.Infra.Messaging.Producer
{
    public abstract class ConfluentProducerBase<T> : IProducer<T>, IDisposable
    {
        private readonly ProducerConfig producerConfig;

        private IProducer<string, string> producer;
        public abstract string Topics { get; }
        public ConfluentProducerBase(ProducerConfig _producerConfig)
        {
            producerConfig = _producerConfig;
            producer = new ConfluentProducerBuilder()
                .AddConfig(_producerConfig)
                .Build();
        }

        public async Task<DeliveryResult<string, string>> ProduceAsync(T message)
        {
            var kafkaMessage = new Message<string, string>()
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonConvert.SerializeObject(message)
            };

            return await producer.ProduceAsync(Topics, kafkaMessage);
        }

        public void Dispose()
        {
            producer.Dispose();
        }
    }
}
