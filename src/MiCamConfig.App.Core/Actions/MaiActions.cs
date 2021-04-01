using DialogMessaging;
using DialogMessaging.Interactions;
using MiCam.Api.Client.Schema;
using MiCamConfig.App.Core.Actions.Base;
using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Core.ViewModels;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;

namespace MiCamConfig.App.Core.Actions
{
    public class MaiActions : BaseActions
    {
        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        public override IList<ActionModel> Actions { get; } = new List<ActionModel>();
        #endregion

        #region Event Handlers
        public override void OnActionClick(ActionModel action)
        {
            switch (action.Data)
            {
                case Code.ApkAuhorize:

                    NavigationService.Navigate<SubmittingRequestViewModel, SubmittingRequestViewModelNavigationParams>(new SubmittingRequestViewModelNavigationParams
                    {
                        Title = action.Title,
                        Task = CoreService.CamClient.AdminOperations.ApkAuthorizeAsync
                    });

                    return;

                case Code.CustomRequest:

                    NavigationService.Navigate<CustomRequestViewModel, CustomRequestViewModelNavigationParams>(new CustomRequestViewModelNavigationParams
                    {
                        DefaultRequest = $"http://192.72.1.1/cgi-bin/Config.cgi?action={RequestElement.Action}&property={RequestElement.Property}&value={RequestElement.Value}"
                    });

                    return;

                case Code.SoundIndicator:

                    var config = new ActionSheetBottomConfig
                    {
                        Title = Resources.TitleSelectAction,
                        CancelButtonText = Resources.ActionCancel,
                        ItemClickAction = (item) =>
                        {
                            NavigationService.Navigate<SubmittingRequestViewModel, SubmittingRequestViewModelNavigationParams>(new SubmittingRequestViewModelNavigationParams
                            {
                                Title = action.Title,
                                Task = item.Data switch
                                {
                                    GetSoundIndicatorOperation => CoreService.CamClient.SoundOperations.GetSoundIndicatorAsync,
                                    SetSoundIndicatorOnOperation => () => CoreService.CamClient.SoundOperations.SetSoundIndicatorAsync("On"),
                                    SetSoundIndicatorOffOperation => () => CoreService.CamClient.SoundOperations.SetSoundIndicatorAsync("Off"),
                                    _ => throw new NotImplementedException("Sound indicator action sheet option not implemented.")
                                }
                            });
                        }
                    };

                    config.Items.Add(new ActionSheetItemConfig { Message = $"{Resources.HintGetValue}", Data = GetSoundIndicatorOperation });
                    config.Items.Add(new ActionSheetItemConfig { Message = $"{Resources.HintSetValueTo}: \"On\"", Data = SetSoundIndicatorOnOperation });
                    config.Items.Add(new ActionSheetItemConfig { Message = $"{Resources.HintSetValueTo}: \"Off\"", Data = SetSoundIndicatorOffOperation });

                    MessagingService.Instance.ActionSheetBottom(config);

                    return;

                default:
                    return;
            } 
        }
        #endregion

        #region Constructors
        public MaiActions(ICoreService coreService, IMvxNavigationService navigationService)
            : base(coreService, navigationService)
        {
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

        #region Constant Values
        public const string GetSoundIndicatorOperation = "get_sound_indicator";
        public const string SetSoundIndicatorOnOperation = "set_sound_indicator_on";
        public const string SetSoundIndicatorOffOperation = "set_sound_indicator_off";
        #endregion
    }
}
