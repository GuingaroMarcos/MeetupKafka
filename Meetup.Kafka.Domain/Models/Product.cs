using Meetup.Kafka.Domain.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Meetup.Kafka.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public Categories Category { get; set; }
        public List<string> Features { get; set; }
        public DateTime SolicitationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsApproved { get; set; }
    }
}
