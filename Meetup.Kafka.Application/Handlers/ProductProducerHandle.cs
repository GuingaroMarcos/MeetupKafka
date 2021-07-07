using Confluent.Kafka;
using MediatR;
using Meetup.Kafka.Application.Request;
using Meetup.Kafka.Infra.Messaging.Producer;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Kafka.Application.Handlers
{
    public class ProductProducerHandle : IRequestHandler<ProductRequest, Unit>
    {
        private readonly IProducer<ProductRequest> _productProducer;
        public ProductProducerHandle(IProducer<ProductRequest> productProducer)
        {
            _productProducer = productProducer;
        }

        public async Task<Unit> Handle(ProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                request.SolicitationTime = DateTime.Now;
                await _productProducer.ProduceAsync(request);
            }
            catch (Exception e) when (e is InvalidOperationException || e is ProduceException<Null, string> )
            {
                throw;
            }

            return Unit.Value;
        }
    }
}
