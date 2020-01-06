using MiCamConfig.App.Core.Interactions;

namespace MiCamConfig.App.Core.Services
{
    public interface IMessagingService
    {
        void Alert(AlertConfig config);
        void HideLoading();
        void ShowLoading(string message);
    }
}
