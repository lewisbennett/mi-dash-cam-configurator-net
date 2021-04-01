using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MiCamConfig.App.Core.ViewModels
{
    public class DisclaimerViewModel : BaseViewModel
    {
        #region Fields
        private readonly IMvxNavigationService _navigationService;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the command triggered when the continue button is clicked.
        /// </summary>
        public IMvxCommand ContinueButtonClickCommand { get; private set; }

        /// <summary>
        /// Gets the text displayed on the continue button.
        /// </summary>
        public string ContinueButtonText => Resources.ActionContinue;

        /// <summary>
        /// Gets the disclaimer message.
        /// </summary>
        public string Message => Resources.MessageDisclaimer;
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

            Title = Resources.TitleDisclaimer;
        }
        #endregion

        #region Constructors
        public DisclaimerViewModel(IMvxNavigationService navigationService)
            : base()
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
