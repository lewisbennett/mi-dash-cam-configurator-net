using DialogMessaging.Interactions;
using MiCam.Api.Client.Entities;
using MiCam.Api.Client.Schema;
using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.Actions
{
    public class MaiActions : AbstractActions
    {
        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        public override IList<ActionModel> Actions { get; } = new List<ActionModel>();
        #endregion

        #region Event Handlers
        public override async void OnActionClick(ActionModel action)
        {
            Func<Task<ResponseEntity>> task = null;

            switch (action.Data)
            {
                case Code.ApkAuhorize:
                    task = CamClient.AdminOperations.ApkAuthorizeAsync;
                    break;

                case Code.CustomRequest:

                    await NavigationService.Navigate<CustomRequestViewModel, CustomRequestViewModelNavigationParams>(new CustomRequestViewModelNavigationParams
                    {
                        DefaultRequest = $"http://192.72.1.1/cgi-bin/Config.cgi?action={RequestElement.Action}&property={RequestElement.Property}&value={RequestElement.Value}"

                    }).ConfigureAwait(false);

                    return;

                case Code.SoundIndicator:

                    var value = await ConfirmSoundIndicatorValueAsync().ConfigureAwait(false);

                    if (value != null)
                        task = value;

                    break;

                default:
                    return;
            }

            await NavigationService.Navigate<SubmittingRequestViewModel, SubmittingRequestViewModelNavigationParams>(new SubmittingRequestViewModelNavigationParams
            {
                Title = action.Title,
                Task = task

            }).ConfigureAwait(false);
        }
        #endregion

        #region Public Methods
        public async Task<Func<Task<ResponseEntity>>> ConfirmSoundIndicatorValueAsync()
        {
            var config = new ActionSheetBottomAsyncConfig
            {
                Title = Resources.TitleSelectAction,
                CancelButtonText = Resources.ActionCancel
            };

            config.Items.Add(new ActionSheetItemAsyncConfig { Message = $"{Resources.HintGetValue}" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Message = $"{Resources.HintSetValueTo}: \"On\"" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Message = $"{Resources.HintSetValueTo}: \"Off\"" });

            var selectedItem = await MessagingService.ActionSheetBottomAsync(config).ConfigureAwait(false);

            if (selectedItem == null || !(selectedItem is ActionSheetItemAsyncConfig selectedAsyncItem))
                return null;

            var index = config.Items.IndexOf(selectedAsyncItem);

            return index switch
            {
                1 => () => CamClient.SoundOperations.SetSoundIndicatorAsync("On"),
                2 => () => CamClient.SoundOperations.SetSoundIndicatorAsync("Off"),
                _ => CamClient.SoundOperations.GetSoundIndicatorAsync,
            };
        }
        #endregion

        #region Constructors
        public MaiActions()
        {
            CreateActions();
        }
        #endregion

        #region Private Methods
        private void CreateActions()
        {
            Actions.Add(new ActionModel { Title = Code.ApkAuhorize, Data = Code.ApkAuhorize });
            Actions.Add(new ActionModel { Title = Code.SoundIndicator, Data = Code.SoundIndicator });
            Actions.Add(new ActionModel { Title = Resources.TitleCustomRequest, Data = Code.CustomRequest });
        }
        #endregion
    }
}
