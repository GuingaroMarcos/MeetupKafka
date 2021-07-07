using Confluent.Kafka;
using Meetup.Kafka.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Kafka.Infra.Messaging.Consumer
{
    public abstract class ConfluentConsumerBase<T> : IConsumer, IDisposable
    {
        private readonly ConsumerConfig consumerConfing;

        private IConsumer<Ignore, string> consumer;
        public abstract string Topic { get; }
        protected ConfluentConsumerBase(ConsumerConfig consumerConfing)
        {
            this.consumerConfing = consumerConfing;
            consumer = new ConfluentConsumerBuilder()
                            .AddConfig(consumerConfing)
                            .Build(Topic);
        }

        public async Task<ConsumeResult<Ignore, string>> ConsumeAsync(CancellationToken cancellationToken)
        {
            return consumer.Consume(cancellationToken);
        }

        public async Task<List<TopicPartitionOffset>> GetStateOfKafka()
        {
            return new ConfluentConsumerBuilder()
                .AddConfig(consumerConfing)
                .BuildCommit();
        }

        public void Dispose()
        {
            consumer.Dispose();
        }

    }
}
