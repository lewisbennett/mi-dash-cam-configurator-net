using MiCam.Api.Client.Schema;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MiCamConfig.App.Core.ViewModels
{
    public class CustomRequestViewModelNavigationParams
    {
        #region Properties
        /// <summary>
        /// Gets or sets the default request.
        /// </summary>
        public string DefaultRequest { get; set; }
        #endregion
    }

    public partial class CustomRequestViewModel : BaseViewModel<CustomRequestViewModelNavigationParams>
    {
        #region Fields
        private readonly IMvxNavigationService _navigationService;
        #endregion

        #region Event Handlers
        private void SubmitButton_Click()
        {
            var request = Request.Replace(RequestElement.Action, Action?.Trim())
                .Replace(RequestElement.Property, Property?.Trim())
                .Replace(RequestElement.Value, Value?.Trim());

            _navigationService.Navigate<SubmittingRequestViewModel, SubmittingRequestViewModelNavigationParams>(new SubmittingRequestViewModelNavigationParams
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

            Action = "set";
            ActionHint = RequestElement.Action;
            PropertyHint = RequestElement.Property;
            RequestHint = Resources.HintRequest;
            SubmitRequestButtonText = Resources.ActionSubmitRequest;
            Title = Resources.TitleCustomRequest;
            ValueHint = RequestElement.Value;
        }

        public override void Prepare(CustomRequestViewModelNavigationParams parameter)
        {
            base.Prepare(parameter);

            Request = parameter?.DefaultRequest;
        }
        #endregion

        #region Constructors
        public CustomRequestViewModel(IMvxNavigationService navigationService)
            : base()
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
