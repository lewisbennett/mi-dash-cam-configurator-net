using DialogMessaging.Interactions;
using MiCam.Api.Client.Entities;
using MiCam.Api.Client.Schema;
using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.Actions
{
    public class MaiActions : AbstractActions
    {
        #region Fields
        private readonly List<ActionModel> _actions = new List<ActionModel>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        public override IList<ActionModel> Actions => _actions.OrderBy(a => a.Title).ToList();
        #endregion

        #region Event Handlers
        public override async void OnActionClick(ActionModel action)
        {
            Func<Task<ResponseEntity>> task = null;

            switch (action.Title)
            {
                case Code.ApkAuhorize:
                    task = CamClient.AdminOperations.ApkAuthorizeAsync;
                    break;

                case Code.SoundIndicator:

                    var value = await ConfirmSoundIndicatorValueAsync().ConfigureAwait(false);

                    if (value != null)
                        task = value;

                    break;

                default:
                    return;
            }

            await NavigationService.Navigate<SubmittingRequestViewModel, SubmittingRequestViewModel.NavigationParams>(new SubmittingRequestViewModel.NavigationParams
            {
                Code = action.Title,
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

            config.Items.Add(new ActionSheetItemAsyncConfig { Text = $"{Resources.HintGetValue}" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Text = $"{Resources.HintSetValueTo}: \"On\"" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Text = $"{Resources.HintSetValueTo}: \"Off\"" });

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
            _actions.Add(new ActionModel { Title = Code.ApkAuhorize });
            _actions.Add(new ActionModel { Title = Code.SoundIndicator });
        }
        #endregion
    }
}
