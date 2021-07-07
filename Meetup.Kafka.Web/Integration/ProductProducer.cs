using Confluent.Kafka;
using Meetup.Kafka.Application.Request;
using Meetup.Kafka.Infra.Messaging.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Kafka.Web.Integration
{
    public class ProductProducer : ConfluentProducerBase<ProductRequest>
    {
        public ProductProducer(ProducerConfig producerConfing) : base(producerConfing)
        {
                
        }
        public override string Topics => "product.new.product";
    }
}
