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
        #endregion
    }
}