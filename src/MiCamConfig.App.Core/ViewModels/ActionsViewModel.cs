using MiCamConfig.App.Core.Actions;
using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ActionsViewModel : ListViewModel<ActionModel, ActionsViewModel.NavigationParams>
    {
        public class NavigationParams
        {
            #region Properties
            /// <summary>
            /// Gets or sets the dash cam actions.
            /// </summary>
            public IActions DashCamActions { get; set; }
            #endregion
        }

        #region Properties
        /// <summary>
        /// Gets the dash cam actions.
        /// </summary>
        public IActions DashCamActions { get; private set; }
        #endregion

        #region Event Handlers
        public override void OnItemClick(ActionModel item)
        {
            base.OnItemClick(item);

            DashCamActions?.OnActionClick(item);
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            Title = Resources.TitleActions;
        }

        public override void Prepare(NavigationParams parameter)
        {
            base.Prepare(parameter);

            DashCamActions = parameter?.DashCamActions;

            if (DashCamActions != null)
                Data.AddRange(DashCamActions.Actions);
        }
        #endregion
    }
}
