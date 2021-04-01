using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Droid.Services;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;

namespace MiCamConfig.App.Droid
{
    public class Setup : MvxAndroidSetup<Core.App>
    {
        #region Public Methods
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAndroidViewPresenter(AndroidViewAssemblies);
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<ICoreService>(() => new CoreService());
        }
        #endregion
    }
}