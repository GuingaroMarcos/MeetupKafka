using MediatR;
using Meetup.Kafka.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace Meetup.Kafka.Application.Request
{
    public class ProductRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public IFormFile PhotoForm { get; set; }
        public Byte[] Photo { get; set; }
        public Categories Category { get; set; }
        public DateTime? SolicitationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool? IsApproved { get; set; }
    }
}
