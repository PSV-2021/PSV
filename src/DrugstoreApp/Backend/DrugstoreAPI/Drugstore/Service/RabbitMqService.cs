using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Drugstore.Models;
using Drugstore.Service;
using DrugstoreAPI.Service;
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
        public MedicineService medicineService;

        public RabbitMQService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            CreateConnection();
            CreateCompletionConnection();
            RecieveMessage();
            RecieveFinishingMessage();
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
        public void CreateCompletionConnection()
        {
            var factory = new ConnectionFactory() { HostName = host };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "tenderFinish", type: ExchangeType.Fanout);
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
        }

        public void RecieveFinishingMessage()
        {
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                              exchange: "tenderFinish",
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
                    Console.WriteLine(" [x] Received {0}", jsonMessage);
                    string message = "";
                    try
                    {   // try deserialize with default datetime format
                        message = JsonConvert.DeserializeObject<string>(jsonMessage);
                        //Console.WriteLine(drugstoreOffer.Id);

                    }
                    catch (Exception)     // datetime format not default, deserialize with Java format (milliseconds since 1970/01/01)
                    {
                        Console.WriteLine("Ne moze");
                    }

                    string[] finishString = message.Split(":");

                    TenderOffer tenderOffer = drugTenderService.getTenderOfferById(finishString[1]);
                    DrugTender drugTender = drugTenderService.getDrugTenderById(tenderOffer.TenderId);

                    if (finishString[0].Equals("Winner"))
                    {
                        tenderOffer.IsAccepted = true;
                        tenderOffer.IsActive = false;
                        drugTenderService.UpdateTenderOffer(tenderOffer);
                        drugTender.isFinished = true;
                        drugTenderService.UpdateDrugTender(drugTender);

                    }
                    else
                    {
                        tenderOffer.IsAccepted = false;
                        tenderOffer.IsActive = false;
                        drugTenderService.UpdateTenderOffer(tenderOffer);
                        drugTender.isFinished = true;
                        drugTenderService.UpdateDrugTender(drugTender);
                    }
                    
                }
            };
            channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);
        }

        

    }
}
