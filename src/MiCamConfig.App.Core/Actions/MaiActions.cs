using MiCam.Api.Client.Schema;
using MiCamConfig.App.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace MiCamConfig.App.Core.Actions
{
    public class MaiActions : IActions
    {
        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        public IList<ActionModel> Actions { get; private set; }
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
            var actions = new List<ActionModel>
            {
                new ActionModel
                {
                    Title = Code.ApkAuhorize,
                    Data = Code.ApkAuhorize
                }
            };

            Actions = new List<ActionModel>(actions.OrderBy(a => a.Title));
        }
        #endregion
    }
}
