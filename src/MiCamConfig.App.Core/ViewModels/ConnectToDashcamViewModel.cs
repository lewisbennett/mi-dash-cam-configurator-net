using DialogMessaging;
using DialogMessaging.Interactions;
using MiCam.Api.Client.Entities;
using MiCamConfig.App.Core.Actions;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MiCamConfig.App.Core.ViewModels
{
    public partial class ConnectToDashcamViewModel : BaseViewModel
    {
        #region Fields
        private bool _isLoading;
        private readonly IMvxNavigationService _navigationService;
        #endregion

        #region Event Handlers
        private void ContinueButton_Click()
        {
            ApkAuthorize();
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

        #region Private Methods
        private void ApkAuthorize()
        {
            if (_isLoading)
                return;

            _isLoading = true;

            MessagingService.Instance.ShowLoadingAsync(new LoadingAsyncConfig
            {
                Message = Resources.MessagingConnecting

            }, CoreService.ExecuteTaskAsync(CoreService.CamClient.AdminOperations.ApkAuthorizeAsync, (response) =>
            {
                if (response is ResponseEntity apkAuthorization && apkAuthorization.Success)
                {
                    _navigationService.Navigate<ActionsViewModel, ActionsViewModelNavigationParams>(new ActionsViewModelNavigationParams
                    {
                        DashCamActions = new MaiActions(CoreService, _navigationService)
                    });
                }
                else
                {
                    MessagingService.Instance.Alert(new AlertConfig
                    {
                        Title = Resources.TitleNotConnected,
                        Message = Resources.MessageNotConnectedToDashcam,
                        OkButtonText = Resources.ActionOkay
                    });
                }

            })).ContinueWith((task) =>
            {
                _isLoading = false;
            });
        }
        #endregion
    }
}
