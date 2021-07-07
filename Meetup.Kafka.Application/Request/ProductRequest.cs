using MediatR;
using Meetup.Kafka.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Meetup.Kafka.Application.Request
{
    public class ProductRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public string PhotoBase64 { get; set; }
        public Categories Category { get; set; }
        //public List<string> Features { get; set; }
        public DateTime? SolicitationTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool? IsApproved { get; set; }
    }
}
