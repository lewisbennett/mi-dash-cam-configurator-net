using MiCamConfig.App.Core.Actions;
using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;
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

    public class ActionsViewModel : ListViewModel<ActionModel, ActionsViewModelNavigationParams>
    {
        #region Fields
        private string _searchText = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the dash cam actions.
        /// </summary>
        public IActions DashCamActions { get; private set; }

        /// <summary>
        /// Gets or sets the placeholder text for the search field.
        /// </summary>
        public string SearchHint => Resources.HintSearch;

        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        public string SearchText
        {
            get => _searchText;

            set
            {
                value ??= string.Empty;

                if (_searchText.Equals(value))
                    return;

                _searchText = value;
                RaisePropertyChanged(() => SearchText);

                Search(_searchText);
            }
        }
        #endregion

        #region Event Handlers
        public override void OnItemClick(ActionModel item)
        {
            base.OnItemClick(item);

            DashCamActions?.OnActionClick(item);
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
    }
}
