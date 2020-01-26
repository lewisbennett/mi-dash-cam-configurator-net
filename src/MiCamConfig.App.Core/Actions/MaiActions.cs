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

                    if (string.IsNullOrWhiteSpace(value))
                        return;

                    task = () => CamClient.SoundOperations.SoundIndicatorAsync(value);

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
        public async Task<string> ConfirmSoundIndicatorValueAsync()
        {
            var config = new ActionSheetBottomAsyncConfig
            {
                Title = Resources.TitleSetValue,
                CancelButtonText = Resources.ActionCancel
            };

            config.Items.Add(new ActionSheetItemAsyncConfig { Text = $"{Resources.HintValue}: On", Data = "On" });
            config.Items.Add(new ActionSheetItemAsyncConfig { Text = $"{Resources.HintValue}: Off", Data = "Off" });

            var selected = await MessagingService.ActionSheetBottomAsync(config).ConfigureAwait(false);

            return selected?.Data as string;
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
