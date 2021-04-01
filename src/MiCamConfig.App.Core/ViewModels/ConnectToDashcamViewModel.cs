using DialogMessaging;
using DialogMessaging.Interactions;
using MiCam.Api.Client.Entities;
using MiCamConfig.App.Core.Actions;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ConnectToDashcamViewModel : BaseViewModel
    {
        #region Fields
        private ResponseEntity _apkAuthorization;
        private readonly IMvxNavigationService _navigationService;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title displayed underneath the dashcam image.
        /// </summary>
        public string ConnectToDashcamTitle => Resources.TitleConnectToDashcam;
        
        /// <summary>
        /// Gets the command triggered when the continue button is clicked.
        /// </summary>
        public IMvxCommand ContinueButtonClickCommand { get; private set; }

        /// <summary>
        /// Gets the text displayed on the continue button.
        /// </summary>
        public string ContinueButtonText => Resources.ActionContinue;

        /// <summary>
        /// Gets the message showing where WiFi settings are located.
        /// </summary>
        public string WifiDirectory => Resources.MessageWifiDirectory;
        #endregion

        #region Event Handlers
        private async void ContinueButton_Click()
        {
            _apkAuthorization = null;

            await MessagingService.Instance.ShowLoadingAsync(new LoadingAsyncConfig
            {
                Message = Resources.MessagingConnecting

            }, RunTaskAsync(ApkAuthorizeAsync)).ConfigureAwait(false);

            if (_apkAuthorization != null && _apkAuthorization.Success)
            {
                await _navigationService.Navigate<ActionsViewModel, ActionsViewModelNavigationParams>(new ActionsViewModelNavigationParams
                {
                    DashCamActions = new MaiActions()

                }).ConfigureAwait(false);

                return;
            }

            MessagingService.Instance.Alert(new AlertConfig
            {
                Title = Resources.TitleNotConnected,
                Message = Resources.MessageNotConnectedToDashcam,
                OkButtonText = Resources.ActionOkay
            });
        }
        #endregion

        #region Public Methods
        public async Task ApkAuthorizeAsync()
        {
            _apkAuthorization = await CamClient.AdminOperations.ApkAuthorizeAsync().ConfigureAwait(false);
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            ContinueButtonClickCommand = new MvxCommand(ContinueButton_Click);

            Title = Resources.TitleConnectToDashcam;
        }
        #endregion

        #region Constructors
        public ConnectToDashcamViewModel(IMvxNavigationService navigationService)
            : base()
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
