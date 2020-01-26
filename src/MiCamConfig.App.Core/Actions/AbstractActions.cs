using DialogMessaging;
using MiCam.Api.Client;
using MiCamConfig.App.Core.Models;
using MvvmCross;
using MvvmCross.Navigation;
using System.Collections.Generic;

namespace MiCamConfig.App.Core.Actions
{
    public abstract class AbstractActions : IActions
    {
        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        public abstract IList<ActionModel> Actions { get; }

        /// <summary>
        /// Gets the app's CamClient.
        /// </summary>
        public CamClient CamClient => AppCore.CamClient;

        /// <summary>
        /// Gets the messaging service.
        /// </summary>
        public IMessagingService MessagingService => DialogMessaging.MessagingService.Instance;

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        public IMvxNavigationService NavigationService { get; } = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        #endregion

        #region Event Handlers
        public abstract void OnActionClick(ActionModel action);
        #endregion
    }
}
