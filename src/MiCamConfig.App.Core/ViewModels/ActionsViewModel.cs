using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ActionsViewModel : ListViewModel<ActionModel>
    {
        #region Properties
        /// <summary>
        /// Gets the title for this ViewModel.
        /// </summary>
        public override string Title => Resources.TitleActions;
        #endregion
    }
}
