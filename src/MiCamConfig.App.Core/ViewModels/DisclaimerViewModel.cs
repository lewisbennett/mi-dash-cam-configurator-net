using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MiCamConfig.App.Core.ViewModels
{
    public partial class DisclaimerViewModel : BaseViewModel
    {
        #region Fields
        private readonly IMvxNavigationService _navigationService;
        #endregion

        #region Event Handlers
        private void ContinueButton_Click()
        {
            _navigationService.Navigate<ConnectToDashcamViewModel>();
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            ContinueButtonClickCommand = new MvxCommand(ContinueButton_Click);

            ContinueButtonText = Resources.ActionContinue;
            Message = Resources.MessageDisclaimer;
            Title = Resources.TitleDisclaimer;
        }
        #endregion

        #region Constructors
        public DisclaimerViewModel(ICoreService coreService, IMvxNavigationService navigationService)
            : base(coreService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
