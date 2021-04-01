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

    public class SubmittingRequestViewModel : BaseViewModel<SubmittingRequestViewModelNavigationParams>
    {
        #region Fields
        private bool _isRequesting;
        private ResponseEntity _response;
        private Func<Task<ResponseEntity>> _task;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets whether the request is currently in progress.
        /// </summary>
        public bool IsRequesting
        {
            get => _isRequesting;

            set
            {
                if (_isRequesting == value)
                    return;

                _isRequesting = value;
                RaisePropertyChanged(() => IsRequesting);
            }
        }

        /// <summary>
        /// Gets the loading message.
        /// </summary>
        public string LoadingMessage => Resources.MessagingSubmittingRequest;

        /// <summary>
        /// Gets the property title.
        /// </summary>
        public string PropertyTitle
        {
            get
            {
                if (Response == null)
                    return $"{Resources.HintProperty}:";

                return $"{Resources.HintProperty}: {Response.PropertyName}";
            }
        }

        /// <summary>
        /// Gets the raw response.
        /// </summary>
        public string RawResponse => Response?.RawResponse;

        /// <summary>
        /// Gets the raw response title.
        /// </summary>
        public string RawResponseTitle => $"{Resources.HintRawResponse}:";

        /// <summary>
        /// Gets or sets the response, if any.
        /// </summary>
        public ResponseEntity Response
        {
            get => _response;

            set
            {
                _response = value;

                RaisePropertyChanged(() => Response);
                RaisePropertyChanged(() => PropertyTitle);
                RaisePropertyChanged(() => RawResponse);
                RaisePropertyChanged(() => SuccessTitle);
                RaisePropertyChanged(() => ValueTitle);
            }
        }

        /// <summary>
        /// Gets the success title.
        /// </summary>
        public string SuccessTitle
        {
            get
            {
                if (Response == null)
                    return $"{Resources.HintSuccess}:";

                return $"{Resources.HintSuccess}: {Response.Success}";
            }
        }

        /// <summary>
        /// Gets the value title.
        /// </summary>
        public string ValueTitle
        {
            get
            {
                if (Response == null)
                    return $"{Resources.HintValue}:";

                return $"{Resources.HintValue}: {Response.Value}";
            }
        }
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

            await CoreService.ExecuteTaskAsync(SubmitTaskAsync).ConfigureAwait(false);

            IsRequesting = false;
        }

        public async Task SubmitTaskAsync()
        {
            var response = await _task.Invoke().ConfigureAwait(false);

            Response = response;
        }
        #endregion

        #region Lifecycle
        public override void Prepare(SubmittingRequestViewModelNavigationParams parameter)
        {
            base.Prepare(parameter);

            if (parameter == null)
                return;

            _task = parameter.Task;
            Title = parameter.Title;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            if (Response == null)
                SubmitTask();
        }
        #endregion

        #region Constructors
        public SubmittingRequestViewModel(ICoreService coreService)
            : base(coreService)
        {
        }
        #endregion
    }
}
