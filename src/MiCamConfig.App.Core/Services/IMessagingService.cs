using MiCamConfig.App.Core.Interactions;
using MvvmCross.ViewModels;

namespace MiCamConfig.App.Core.Services
{
    public interface IMessagingService
    {
        void Alert(AlertConfig config);
        MvxInteraction<AlertConfig> AlertInteraction { get; }
    }
}
