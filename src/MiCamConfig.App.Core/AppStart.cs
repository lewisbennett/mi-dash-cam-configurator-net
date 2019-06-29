using MiCamConfig.App.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core
{
    public class AppStart : MvxAppStart
    {
        #region Public Methods
        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            await NavigationService.Navigate<ConnectToDashcamViewModel>();
        }
        #endregion

        #region Constructors
        public AppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
        }
        #endregion
    }
}
