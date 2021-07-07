
using Confluent.Kafka;
using Meetup.Kafka.Domain.Models;
using Meetup.Kafka.Infra.Messaging.Consumer;
using Meetup.Kafka.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.Kafka.Web.HostedService.Consumer
{
    public class ConsumerBase : BackgroundService
    {
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly IConsumer _notificationConsumer;
        public ConsumerBase(IHubContext<NotificationHub> _hubContext, IConsumer notificationConsumer)
        {
            hubContext = _hubContext;
            _notificationConsumer = notificationConsumer;
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                while(!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var message = _notificationConsumer.ConsumeAsync(cancellationToken).Result;

                        if (message is not null)
                        {
                            var request = JsonConvert.DeserializeObject<Notification>(message.Value);

                            hubContext.Clients.All.SendAsync("ReadNotification", message);
                        }
                    }
                    catch (ConsumeException ex)
                    {
                        throw;
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                }

            }, cancellationToken);
        }
    }
}
