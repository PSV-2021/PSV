using Integration.Model;
using RabbitMQ.Client;
using System.Threading;
using System.Threading.Tasks;

namespace PrimerServis
{
    public interface IRabbitMQService
    {
        void CreateConnection();
        DrugstoreOffer RecieveMessage();
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}