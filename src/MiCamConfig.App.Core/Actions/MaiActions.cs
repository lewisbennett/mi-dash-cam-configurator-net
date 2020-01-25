using MiCam.Api.Client.Schema;
using MiCamConfig.App.Core.Models;
using System.Collections.Generic;

namespace MiCamConfig.App.Core.Actions
{
    public class MaiActions : IActions
    {
        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        public IList<ActionModel> Actions { get; } = new List<ActionModel>();
        #endregion

        #region Event Handlers
        public void OnActionClick(ActionModel action)
        {
            switch (action.Data)
            {
                case Code.ApkAuhorize:
                    return;

                default:
                    return;
            }
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
            Actions.Add(new ActionModel
            {
                Title = Code.ApkAuhorize,
                Data = Code.ApkAuhorize
            });
        }
        #endregion
    }
}
