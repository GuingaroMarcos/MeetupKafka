using Meetup.Kafka.Domain.Enum;
using System;

namespace Meetup.Kafka.Domain.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
