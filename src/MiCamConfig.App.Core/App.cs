using MvvmCross.ViewModels;

namespace MiCamConfig.App.Core
{
    public class App : MvxApplication
    {
        #region Lifecycle
        public override void Initialize()
        {
            RegisterCustomAppStart<AppStart>();
        }
        #endregion
    }
}
