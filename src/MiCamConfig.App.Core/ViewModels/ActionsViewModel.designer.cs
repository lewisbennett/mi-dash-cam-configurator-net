namespace MiCamConfig.App.Core.ViewModels
{
    partial class ActionsViewModel
    {
        #region Fields
        private string _searchHint, _searchText;
        #endregion

        #region Properties
        public string SearchHint
        {
            get => _searchHint;

            set => SetProperty(ref _searchHint, value);
        }

        public string SearchText
        {
            get => _searchText;

            set
            {
                // TODO - remove this
                if (SetProperty(ref _searchText, value))
                    Search(_searchText);
            }
        }
        #endregion
    }
}
