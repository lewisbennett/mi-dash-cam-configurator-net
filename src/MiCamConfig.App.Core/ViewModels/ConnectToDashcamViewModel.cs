using DialogMessaging;
using DialogMessaging.Interactions;
using MiCam.Api.Client.Entities;
using MiCamConfig.App.Core.Actions;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.ViewModels
{
    public partial class ConnectToDashcamViewModel : BaseViewModel
    {
        #region Fields
        private ResponseEntity _apkAuthorization;
        private readonly IMvxNavigationService _navigationService;
        #endregion

        #region Event Handlers
        private async void ContinueButton_Click()
        {
            _apkAuthorization = null;

            await MessagingService.Instance.ShowLoadingAsync(new LoadingAsyncConfig
            {
                Message = Resources.MessagingConnecting

            }, CoreService.ExecuteTaskAsync(ApkAuthorizeAsync)).ConfigureAwait(false);

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
            _apkAuthorization = await CoreService.CamClient.AdminOperations.ApkAuthorizeAsync().ConfigureAwait(false);
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            ContinueButtonClickCommand = new MvxCommand(ContinueButton_Click);

            ConnectToDashcamTitle = Resources.TitleConnectToDashcam;
            ContinueButtonText = Resources.ActionContinue;
            Title = Resources.TitleConnectToDashcam;
            WifiDirectory = Resources.MessageWifiDirectory;
        }
        #endregion

        #region Constructors
        public ConnectToDashcamViewModel(ICoreService coreService, IMvxNavigationService navigationService)
            : base(coreService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
