using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Model.DataBaseContext;
using Integration_API.Repository.Interfaces;
using Integration.Repository.Sql;
using RabbitMQ.Client.Events;
using Integration.Model;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugstoreOfferController : ControllerBase
    {

        private readonly MyDbContext dbContext;
        ConnectionFactory factory { get; set; }
        IConnection connection { get; set; }
        IModel channel { get; set; }


        public DrugstoreOfferController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            this.factory = new ConnectionFactory() { HostName = "localhost" };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }
        

        public void RecieveOffer()
        {


            IDrugstoreOfferRepository repo = new DrugstoreOfferRepository(dbContext);
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: "logs",
                                  routingKey: "");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    var jsonMessage = Encoding.UTF8.GetString(body);
                    DrugstoreOffer drugstoreOffer = new DrugstoreOffer();
                    try
                    {   // try deserialize with default datetime format
                        drugstoreOffer = JsonConvert.DeserializeObject<DrugstoreOffer>(jsonMessage);
                        Console.WriteLine(drugstoreOffer.Content);
                    }
                    catch (Exception)     // datetime format not default, deserialize with Java format (milliseconds since 1970/01/01)
                    {
                        Console.WriteLine("Ne moze");
                    }
                    Console.WriteLine(" [x] Received {0}", drugstoreOffer);
                    //repo.Save(drugstoreOffer);
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
        public  DrugstoreOfferController()
        {
            this.factory = new ConnectionFactory() { HostName = "localhost" };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();

        }

        public void Deregister()
        {
            this.connection.Close();
        }

    }
}
