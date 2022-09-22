using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IPushNotificationService
    {
        Task<bool> SendNotification(object data);
    }
}
