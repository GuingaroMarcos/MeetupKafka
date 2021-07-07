using Confluent.Kafka;
using MediatR;
using Meetup.Kafka.Application.Request;
using Meetup.Kafka.Infra.Messaging.Producer;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
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
                request.Photo = ConvertTo(request.PhotoForm);
                await _productProducer.ProduceAsync(request);
            }
            catch (Exception e) when (e is InvalidOperationException || e is ProduceException<Null, string> )
            {
                throw;
            }

            return Unit.Value;
        }

        private static Byte[] ConvertTo(IFormFile formFile)
        {
            using (var ms = new MemoryStream())
            {
                if (formFile is not null)
                {
                    formFile.CopyTo(ms);
                    return ms.ToArray(); 
                }

                return null;
            }
        }
    }
}
