using Confluent.Kafka;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Kafka.Infra.Messaging.Consumer
{
    public interface IConsumer
    {
        Task<ConsumeResult<Ignore, string>> ConsumeAsync(CancellationToken cancellationToken);
        Task<List<TopicPartitionOffset>> GetStateOfKafka();
    }
}
