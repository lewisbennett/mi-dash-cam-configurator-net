using MiCamConfig.App.Core.Actions;
using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.Services;
using System;
using System.Linq;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ActionsViewModelNavigationParams
    {
        #region Properties
        /// <summary>
        /// Gets or sets the dash cam actions.
        /// </summary>
        public IActions DashCamActions { get; set; }
        #endregion
    }

    public partial class ActionsViewModel : ListViewModel<ActionModel, ActionsViewModelNavigationParams>
    {
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

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(SearchText):
                    Search(SearchText);
                    return;

                default:
                    return;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Searches the data for any matching actions.
        /// </summary>
        /// <param name="search">The search.</param>
        public void Search(string search)
        {
            if (DashCamActions == null)
                return;

            Data.SwitchTo(DashCamActions.Actions.Where(a => a.Title.StartsWith(search, StringComparison.CurrentCultureIgnoreCase)) ?? DashCamActions.Actions);

            RaisePropertyChanged(() => IsDataEmpty);
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            SearchHint = Resources.HintSearch;
            Title = Resources.TitleActions;
        }

        public override void Prepare(ActionsViewModelNavigationParams parameter)
        {
            base.Prepare(parameter);

            DashCamActions = parameter?.DashCamActions;

            if (DashCamActions != null)
                Data.AddRange(DashCamActions.Actions);
        }
        #endregion

        #region Constructors
        public ActionsViewModel(ICoreService coreService)
            : base(coreService)
        {
        }
        #endregion
    }
}
