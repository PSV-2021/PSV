using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Drugstore.Models;
using Drugstore.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PrimerServis
{
    public class RabbitMQService : BackgroundService, IRabbitMQService
    {
        IConnection connection;
        IModel channel;
        private string host = Environment.GetEnvironmentVariable("RABBIT_HOST") ?? "localhost";
        private readonly IServiceScopeFactory scopeFactory;
        public DrugTenderService drugTenderService;


        public RabbitMQService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            CreateConnection();
            RecieveMessage();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
        public void CreateConnection()
        {
            var factory = new ConnectionFactory() { HostName = host };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "tender", type: ExchangeType.Fanout);
        }
        public DrugTender RecieveMessage()
        {
            DrugTender drugTender = new DrugTender();
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                              exchange: "tender",
                              routingKey: "");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                using (var scope = scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                    drugTenderService = new DrugTenderService(dbContext);
                    byte[] body = ea.Body.ToArray();
                    var jsonMessage = Encoding.UTF8.GetString(body);

                    try
                    {   // try deserialize with default datetime format
                        drugTender = JsonConvert.DeserializeObject<DrugTender>(jsonMessage);
                        Console.WriteLine(drugTender.Id);

                    }
                    catch (Exception)     // datetime format not default, deserialize with Java format (milliseconds since 1970/01/01)
                    {
                        Console.WriteLine("Ne moze");
                    }
                    Console.WriteLine(" [x] Received {0}", drugTender);
                    drugTenderService.Save(drugTender);
                }
            };
            channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);
            return drugTender;
            /*            return null;*/
        }

        DrugTender IRabbitMQService.RecieveMessage()
        {
            throw new NotImplementedException();
        }
    }
}
