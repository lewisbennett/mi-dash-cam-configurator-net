namespace MiCamConfig.App.Core.ViewModels.Base
{
    partial class BaseViewModel
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
