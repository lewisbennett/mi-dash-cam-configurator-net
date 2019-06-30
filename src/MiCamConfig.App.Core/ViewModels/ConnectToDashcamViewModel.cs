using MiCamConfig.App.Core.Base;
using MiCamConfig.App.Core.Properties;
using MvvmCross.Commands;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ConnectToDashcamViewModel : BaseViewModel
    {
        #region Fields
        private IMvxCommand _continueButtonClickCommand;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title displayed underneath the dashcam image.
        /// </summary>
        public string ConnectToDashcamTitle => Resources.TitleConnectToDashcam;
        
        /// <summary>
        /// Gets the command triggered when the continue button is clicked.
        /// </summary>
        public IMvxCommand ContinueButtonClickCommand
        {
            get
            {
                _continueButtonClickCommand = _continueButtonClickCommand ?? new MvxCommand(ContinueButton_Click);

                return _continueButtonClickCommand;
            }
        }

        /// <summary>
        /// Gets the text displayed on the continue button.
        /// </summary>
        public string ContinueButtonText => Resources.ActionContinue;

        /// <summary>
        /// Gets the title for this ViewModel.
        /// </summary>
        public override string Title => Resources.TitleConnectToDashcam;

        /// <summary>
        /// Gets the message showing where WiFi settings are located.
        /// </summary>
        public string WifiDirectory => Resources.MessageWifiDirectory;
        #endregion

        #region Event Handlers
        private void ContinueButton_Click()
        {
        }
        #endregion
    }
}
