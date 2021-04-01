using MvvmCross.Commands;

namespace MiCamConfig.App.Core.ViewModels
{
    partial class DisclaimerViewModel
    {
        #region Fields
        private IMvxCommand _continueButtonClickCommand;
        private string _continueButtonText, _message;
        #endregion

        #region Properties
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

        public string Message
        {
            get => _message;

            set => SetProperty(ref _message, value);
        }
        #endregion
    }
}
