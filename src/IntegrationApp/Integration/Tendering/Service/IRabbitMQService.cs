using Integration.Model;
using Integration.Tendering.Model;
using RabbitMQ.Client;
using System.Threading;
using System.Threading.Tasks;

namespace PrimerServis
{
    public interface IRabbitMQService
    {
        void CreateConnection();
        DrugstoreOffer RecieveMessage();
        TenderOffer RecieveTenderOffer();
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}