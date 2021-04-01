using MiCamConfig.App.Core.Models;
using System.Collections.Generic;

namespace MiCamConfig.App.Core.Actions.Base
{
    public interface IActions
    {
        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        IList<ActionModel> Actions { get; }
        #endregion

        #region Event Handlers
        void OnActionClick(ActionModel action);
        #endregion
    }
}
