using MiCamConfig.App.Core.Models;
using System.Collections.Generic;

namespace MiCamConfig.App.Core.Actions
{
    public interface IActions
    {
        IList<ActionModel> Actions { get; }
        void OnActionClick(ActionModel action);
    }
}
