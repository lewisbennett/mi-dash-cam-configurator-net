using MiCamConfig.App.Droid.Services;
using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters;

namespace MiCamConfig.App.Droid
{
    public class Setup : MvxAppCompatSetup<Core.App>
    {
        #region Public Methods
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
        }
        #endregion

        #region Lifecycle
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IPermissionsService>(() => new PermissionsService());
            Mvx.IoCProvider.RegisterSingleton<IWifiScanningService>(() => new WifiScanningService());
            Mvx.IoCProvider.RegisterSingleton<IMessagingService>(() => new MessagingService());
        }
        #endregion
    }
}