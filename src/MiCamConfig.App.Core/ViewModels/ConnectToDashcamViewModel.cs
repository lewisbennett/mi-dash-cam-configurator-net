﻿using DialogMessaging.Interactions;
using MiCam.Api.Client.Entities;
using MiCamConfig.App.Core.Actions;
using MiCamConfig.App.Core.Base;
using MiCamConfig.App.Core.Properties;
using MvvmCross.Commands;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ConnectToDashcamViewModel : BaseViewModel
    {
        #region Fields
        private ResponseEntity _apkAuthorization;
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

            await MessagingService.ShowLoadingAsync(Resources.MessagingConnecting, RunTaskAsync(ApkAuthorizeAsync)).ConfigureAwait(false);

            if (_apkAuthorization != null && _apkAuthorization.Success)
            {
                await NavigationService.Navigate<ActionsViewModel, ActionsViewModel.NavigationParams>(new ActionsViewModel.NavigationParams
                {
                    DashCamActions = new MaiActions()

                }).ConfigureAwait(false);

                return;
            }

            MessagingService.Alert(new AlertConfig
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
    }
}
