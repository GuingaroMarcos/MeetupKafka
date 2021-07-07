namespace Meetup.Kafka.Domain.Confgs
{
    public class KafkaConfigs
    {
        public string BootstrapServers { get; set; }
        public int MessageTimeoutMs { get; set; }
        public int MessageSendMaxRetries { get; set; }
    }
}
