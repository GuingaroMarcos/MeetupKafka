using Confluent.Kafka;
using Meetup.Kafka.Domain.Models;
using Meetup.Kafka.Infra.Messaging.Consumer;

namespace Meetup.Kafka.Web.Integration
{
    public class DashConsumer : ConfluentConsumerBase<Notification>
    {
        public DashConsumer(ConsumerConfig consumerConfig): base (consumerConfig)
        {

        }


        public override string Topic => throw new System.NotImplementedException();

    }
}
