using MiCamConfig.App.Core.Models.Base;

namespace MiCamConfig.App.Core.Models
{
    public partial class ActionModel : BaseModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets the optional data payload.
        /// </summary>
        public object Data { get; set; }
        #endregion
    }
}
