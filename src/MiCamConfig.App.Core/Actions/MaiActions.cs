using MiCam.Api.Client.Entities;
using MiCam.Api.Client.Schema;
using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.Actions
{
    public class MaiActions : AbstractActions
    {
        #region Fields
        private readonly List<ActionModel> _actions = new List<ActionModel>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the actions.
        /// </summary>
        public override IList<ActionModel> Actions => _actions.OrderBy(a => a.Title).ToList();
        #endregion

        #region Event Handlers
        public override void OnActionClick(ActionModel action)
        {
            Func<Task<ResponseEntity>> task = null;

            switch (action.Data)
            {
                case Code.ApkAuhorize:
                    task = CamClient.AdminOperations.ApkAuthorizeAsync;
                    break;

                default:
                    return;
            }

            NavigationService.Navigate<SubmittingRequestViewModel, SubmittingRequestViewModel.NavigationParams>(new SubmittingRequestViewModel.NavigationParams
            {
                Code = action.Title,
                Task = task
            });
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
            _actions.Add(new ActionModel
            {
                Title = Code.ApkAuhorize,
                Data = Code.ApkAuhorize
            });
        }
        #endregion
    }
}
