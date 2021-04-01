using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Services;
using MvvmCross.Navigation;
using System.Collections.Generic;

namespace MiCamConfig.App.Core.Actions.Base
{
    public abstract class BaseActions : IActions
    {
        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        public abstract IList<ActionModel> Actions { get; }

        /// <summary>
        /// Gets the app's <see cref="ICoreService" />.
        /// </summary>
        public ICoreService CoreService { get; }

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        public IMvxNavigationService NavigationService { get; }
        #endregion

        #region Event Handlers
        public abstract void OnActionClick(ActionModel action);
        #endregion

        #region Constructors
        protected BaseActions(ICoreService coreService, IMvxNavigationService navigationService)
            : base()
        {
            CoreService = coreService;
            NavigationService = navigationService;
        }
        #endregion
    }
}
