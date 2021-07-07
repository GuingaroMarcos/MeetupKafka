using Confluent.Kafka;
using Meetup.Kafka.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Kafka.Web.HostedService.Consumer
{
    public class DashConsumer : BackgroundService
    {
        private readonly IConsumer<Ignore, string> consumers;
        private readonly IHubContext<DashHub> hubContext;
        public DashConsumer(IHubContext<DashHub> _hubContext, IConsumer<Ignore,string> _consumers)
        {
            hubContext = _hubContext;
            consumers = _consumers;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var action = new List<Action>();

            Action Notif = () => 
            {
                try
                {
                    while (true)
                    {
                        var consumersTask = consumers.Commit();

                        if (consumersTask is not null)
                        {
                            hubContext.Clients.All.SendAsync("ReadDash", consumersTask);
                        }

                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
                    }
                }
                catch (ConsumeException ex)
                {
                    throw;
                }
                catch (OperationCanceledException)
                {
                    throw;
                };
            };

        }
    }
}
