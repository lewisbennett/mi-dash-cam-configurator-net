using MvvmCross.Commands;

namespace MiCamConfig.App.Core.ViewModels
{
    partial class ConnectToDashcamViewModel
    {
        #region Fields
        private string _connectToDashcamTitle, _continueButtonText, _wifiDirectory;
        private IMvxCommand _continueButtonClickCommand;
        #endregion

        #region Properties
        public string ConnectToDashcamTitle
        {
            get => _connectToDashcamTitle;

            set => SetProperty(ref _connectToDashcamTitle, value);
        }

        public IMvxCommand ContinueButtonClickCommand
        {
            get => _continueButtonClickCommand;

            set => SetProperty(ref _continueButtonClickCommand, value);
        }

        public string ContinueButtonText
        {
            get => _continueButtonText;

            set => SetProperty(ref _continueButtonText, value);
        }

        public string WifiDirectory
        {
            get => _wifiDirectory;

            set => SetProperty(ref _wifiDirectory, value);
        }
        #endregion
    }
}
