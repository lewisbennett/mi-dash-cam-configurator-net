using MiCamConfig.App.Core.Actions.Base;
using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Core.ViewModels.List.Base;
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

    public partial class ActionsViewModel : PrimaryListBaseViewModel<ActionModel, ActionsViewModelNavigationParams>
    {
        #region Properties
        /// <summary>
        /// Gets the dash cam actions.
        /// </summary>
        public IActions DashCamActions { get; private set; }
        #endregion

        #region Event Handlers
        protected override void OnPrimaryItemClicked(ActionModel item)
        {
            base.OnPrimaryItemClicked(item);

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

            PrimaryData.SwitchTo(DashCamActions.Actions.Where(a => a.Title.StartsWith(search, StringComparison.CurrentCultureIgnoreCase)) ?? DashCamActions.Actions);

            IsDataEmpty = CalculateIsDataEmpty();
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
            DashCamActions = parameter?.DashCamActions;

            if (DashCamActions != null)
                PrimaryData.AddRange(DashCamActions.Actions);
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
