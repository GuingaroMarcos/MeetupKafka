using Confluent.Kafka;
using Meetup.Kafka.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Kafka.Infra.Messaging.Consumer
{
    public abstract class ConfluentConsumerBase<T> : IConsumer, IDisposable
    {
        private readonly ConsumerConfig consumerConfing;

        private IConsumer<Ignore, string> consumer;
        public abstract string Topics { get; }
        protected ConfluentConsumerBase(ConsumerConfig consumerConfing)
        {
            this.consumerConfing = consumerConfing;
            consumer = new ConfluentConsumerBuilder()
                            .AddConfig(consumerConfing)
                            .Build(Topics);
        }

        public async Task<ConsumeResult<Ignore, string>> ConsumeAsync(CancellationToken cancellationToken)
        {
            return consumer.Consume(cancellationToken);
        }

        public void Dispose()
        {
            consumer.Dispose();
        }

    }
}
