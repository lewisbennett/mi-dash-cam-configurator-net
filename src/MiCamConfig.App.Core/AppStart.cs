using MiCamConfig.App.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core
{
    public class AppStart : MvxAppStart
    {
        #region Public Methods
        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<DisclaimerViewModel>();
        }
        #endregion

        #region Constructors
        public AppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
        }
        #endregion
    }
}
