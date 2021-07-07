using Confluent.Kafka;
using Meetup.Kafka.Domain.Models;
using Meetup.Kafka.Infra.Messaging.Consumer;

namespace Meetup.Kafka.Web.Integration
{
    public class NotificationConsumer : ConfluentConsumerBase<Notification>
    {
        public NotificationConsumer(ConsumerConfig consumerConfig) : base(consumerConfig)
        {

        }
        public override string Topics => "invoice.status.update";
    }
}
