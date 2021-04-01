using MvvmCross.Commands;

namespace MiCamConfig.App.Core.ViewModels
{
    partial class CustomRequestViewModel
    {
        #region Fields
        private string _action, _actionHint, _property, _propertyHint, _request, _requestHint, _submitRequestButtonText, _value, _valueHint;
        private IMvxCommand _submitRequestButtonClickCommand;
        #endregion

        #region Properties
        public string Action
        {
            get => _action;

            set => SetProperty(_action, value);
        }

        public string ActionHint
        {
            get => _actionHint;

            set => SetProperty(ref _actionHint, value);
        }

        public string Property
        {
            get => _property;

            set => SetProperty(ref _property, value);
        }
        
        public string PropertyHint
        {
            get => _propertyHint;

            set => SetProperty(ref _propertyHint, value);
        }

        public string Request
        {
            get => _request;

            set => SetProperty(ref _request, value);
        }

        public string RequestHint
        {
            get => _requestHint;

            set => SetProperty(ref _requestHint, value);
        }

        public IMvxCommand SubmitRequestButtonClickCommand
        {
            get => _submitRequestButtonClickCommand;

            set => SetProperty(ref _submitRequestButtonClickCommand, value);
        }

        public string SubmitRequestButtonText
        {
            get => _submitRequestButtonText;

            set => SetProperty(ref _submitRequestButtonText, value);
        }

        public string Value
        {
            get => _value;

            set => SetProperty(ref _value, value);
        }

        public string ValueHint
        {
            get => _valueHint;

            set => SetProperty(ref _valueHint, value);
        }
        #endregion
    }
}
