using MiCam.Api.Client.Schema;
using MiCamConfig.App.Core.Base;
using MiCamConfig.App.Core.Properties;
using MvvmCross.Commands;

namespace MiCamConfig.App.Core.ViewModels
{
    public class CustomRequestViewModel : BaseViewModel<CustomRequestViewModel.NavigationParams>
    {
        public class NavigationParams
        {
            #region Properties
            /// <summary>
            /// Gets or sets the default request.
            /// </summary>
            public string DefaultRequest { get; set; }
            #endregion
        }

        #region Fields
        private string _action = "set", _property = string.Empty, _request = string.Empty, _value = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        public string Action
        {
            get => _action;

            set
            {
                value ??= string.Empty;

                if (_action.Equals(value))
                    return;

                _action = value;
                RaisePropertyChanged(() => Action);
            }
        }

        /// <summary>
        /// Gets the placeholder text for the action field.
        /// </summary>
        public string ActionHint => RequestElement.Action;

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        public string Property
        {
            get => _property;

            set
            {
                value ??= string.Empty;

                if (_property.Equals(value))
                    return;

                _property = value;
                RaisePropertyChanged(() => Property);
            }
        }

        /// <summary>
        /// Gets the placeholder text for the property field.
        /// </summary>
        public string PropertyHint => RequestElement.Property;

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        public string Request
        {
            get => _request;

            set
            {
                value ??= string.Empty;

                if (_request.Equals(value))
                    return;

                _request = value;
                RaisePropertyChanged(() => Request);
            }
        }

        /// <summary>
        /// Gets the placeholder text for the request field.
        /// </summary>
        public string RequestHint => Resources.HintRequest;

        /// <summary>
        /// Gets the submit button click command.
        /// </summary>
        public IMvxCommand SubmitRequestButtonClickCommand { get; private set; }

        /// <summary>
        /// Gets the text displayed on the submit request button.
        /// </summary>
        public string SubmitRequestButtonText => Resources.ActionSubmitRequest;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value
        {
            get => _value;

            set
            {
                value ??= string.Empty;

                if (_value.Equals(value))
                    return;

                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        /// <summary>
        /// Gets the placeholder text for the value field.
        /// </summary>
        public string ValueHint => RequestElement.Value;
        #endregion

        #region Event Handlers
        private void SubmitButton_Click()
        {
            var request = Request.Replace(RequestElement.Action, Action?.Trim())
                .Replace(RequestElement.Property, Property?.Trim())
                .Replace(RequestElement.Value, Value?.Trim());

            NavigationService.Navigate<SubmittingRequestViewModel, SubmittingRequestViewModel.NavigationParams>(new SubmittingRequestViewModel.NavigationParams
            {
                Title = Resources.TitleCustomRequest,
                Task = () => CamClient.RequestAsync(request)
            });
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            SubmitRequestButtonClickCommand = new MvxCommand(SubmitButton_Click);

            Title = Resources.TitleCustomRequest;
        }

        public override void Prepare(NavigationParams parameter)
        {
            base.Prepare(parameter);

            Request = parameter?.DefaultRequest;
        }
        #endregion
    }
}
