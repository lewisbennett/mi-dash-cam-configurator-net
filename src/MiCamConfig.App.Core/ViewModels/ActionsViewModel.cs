using MiCamConfig.App.Core.Models;
using MiCamConfig.App.Core.Properties;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ActionsViewModel : ListViewModel<ActionModel>
    {
        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            Title = Resources.TitleActions;
        }
        #endregion
    }
}
