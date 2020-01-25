using MiCamConfig.App.Core.Base;
using MiCamConfig.App.Core.Properties;
using MvvmCross.Commands;

namespace MiCamConfig.App.Core.ViewModels
{
    public class DisclaimerViewModel : BaseViewModel
    {
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
            NavigationService.Navigate<ConnectToDashcamViewModel>();
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
    }
}
