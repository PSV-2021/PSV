using Drugstore.Models;
using RabbitMQ.Client;
using System.Threading;
using System.Threading.Tasks;

namespace PrimerServis
{
    public interface IRabbitMQService
    {
        void CreateConnection();
        DrugTender RecieveMessage();
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}