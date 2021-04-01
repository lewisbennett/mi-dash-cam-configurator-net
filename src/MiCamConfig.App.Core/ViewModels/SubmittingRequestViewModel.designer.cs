namespace MiCamConfig.App.Core.ViewModels
{
    partial class SubmittingRequestViewModel
    {
        #region Fields
        private bool _isRequesting;
        private string _loadingMessage, _propertyTitle, _rawResponse, _rawResponseTitle, _successTitle, _valueTitle;
        #endregion

        #region Properties
        public bool IsRequesting
        {
            get => _isRequesting;

            set => SetProperty(ref _isRequesting, value);
        }

        public string LoadingMessage
        {
            get => _loadingMessage;

            set => SetProperty(ref _loadingMessage, value);
        }

        public string PropertyTitle
        {
            get => _propertyTitle;

            set => SetProperty(ref _propertyTitle, value);
        }

        public string RawResponse
        {
            get => _rawResponse;

            set => SetProperty(ref _rawResponse, value);
        }

        public string RawResponseTitle
        {
            get => _rawResponseTitle;

            set => SetProperty(ref _rawResponseTitle, value);
        }

        public string SuccessTitle
        {
            get => _successTitle;

            set => SetProperty(ref _successTitle, value);
        }

        public string ValueTitle
        {
            get => _valueTitle;

            set => SetProperty(ref _valueTitle, value);
        }
        #endregion
    }
}
