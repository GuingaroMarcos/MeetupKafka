using Confluent.Kafka;
using System.Threading.Tasks;

namespace Meetup.Kafka.Infra.Messaging.Producer
{
    public interface IProducer<T>
    {
        Task<DeliveryResult<string, string>> ProduceAsync(T message);
    }
}