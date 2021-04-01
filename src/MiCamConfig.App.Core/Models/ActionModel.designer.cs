namespace MiCamConfig.App.Core.Models
{
    partial class ActionModel
    {
        #region Fields
        private string _title;
        #endregion

        #region Properties
        public string Title
        {
            get => _title;

            set => SetProperty(ref _title, value);
        }
        #endregion
    }
}
