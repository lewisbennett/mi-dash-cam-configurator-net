using Android.Content;
using MiCamConfig.App.Core.Interactions;
using MvvmCross.ViewModels;

namespace MiCamConfig.App.Droid.Services
{
    public interface IMessagingService
    {
        void Alert(AlertConfig config);
        IMvxInteraction<AlertConfig> AlertInteraction { get; set; }
        Context Context { get; set; }
    }
}