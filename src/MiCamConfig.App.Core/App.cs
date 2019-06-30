using MiCamConfig.App.Core.Services;
using MvvmCross;
using MvvmCross.ViewModels;

namespace MiCamConfig.App.Core
{
    public class App : MvxApplication
    {
        #region Lifecycle
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterSingleton<IWifiService>(() => new WifiService());

            RegisterCustomAppStart<AppStart>();
        }
        #endregion
    }
}
