using MiCam.Api.Client.Entities;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.ViewModels
{
    public class SubmittingRequestViewModelNavigationParams
    {
        #region Properties
        /// <summary>
        /// Gets or sets the request code.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the task to execute.
        /// </summary>
        public Func<Task<ResponseEntity>> Task { get; set; }
        #endregion
    }

    public partial class SubmittingRequestViewModel : BaseViewModel<SubmittingRequestViewModelNavigationParams>
    {
        #region Fields
        private ResponseEntity _response;
        private Func<Task<ResponseEntity>> _task;
        #endregion

        #region Public Methods
        /// <summary>
        /// Submits the task.
        /// </summary>
        public async void SubmitTask()
        {
            if (IsRequesting)
                return;

            IsRequesting = true;

            await CoreService.ExecuteTaskAsync(_task.Invoke, (response) =>
            {
                _response = response;

                RawResponse = _response.RawResponse;

                PropertyTitle = CalculatePropertyTitle();
                SuccessTitle = CalculateSuccessTitle();
                ValueTitle = CalculateValueTitle();

            }, HandleException).ConfigureAwait(false);

            IsRequesting = false;
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            LoadingMessage = Resources.MessagingSubmittingRequest;
            RawResponseTitle = $"{Resources.HintRawResponse}:";

            PropertyTitle = CalculatePropertyTitle();
            SuccessTitle = CalculateSuccessTitle();
            ValueTitle = CalculateValueTitle();
        }

        public override void Prepare(SubmittingRequestViewModelNavigationParams parameter)
        {
            _task = parameter.Task;

            Title = parameter.Title;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            if (_response == null)
                SubmitTask();
        }
        #endregion

        #region Constructors
        public SubmittingRequestViewModel(ICoreService coreService)
            : base(coreService)
        {
        }
        #endregion

        #region Private Methods
        private string CalculatePropertyTitle()
        {
            var propertyTitle = $"{Resources.HintProperty}:";

            if (_response != null)
                propertyTitle = $"{propertyTitle} {_response.PropertyName}";

            return propertyTitle;
        }

        private string CalculateSuccessTitle()
        {
            var successTitle = $"{Resources.HintSuccess}:";

            if (_response != null)
                successTitle = $"{successTitle} {_response.Success}";

            return successTitle;
        }

        private string CalculateValueTitle()
        {
            var valueTitle = $"{Resources.HintValue}:";

            if (_response != null)
                valueTitle = $"{valueTitle} {_response.Value}";

            return valueTitle;
        }
        #endregion
    }
}
