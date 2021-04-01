using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace MiCamConfig.App.Core.ViewModels.List.Base
{
    partial class PrimaryListBaseViewModel
    {
        #region Fields
        private IMvxCommand _dataEmptyActionButtonClickCommand;
        private string _dataEmptyHint, _loadingHint, _middleMessage;
        private bool _isDataEmpty, _showLoading;
        #endregion

        #region Properties
        public IMvxCommand DataEmptyActionButtonClickCommand
        {
            get => _dataEmptyActionButtonClickCommand;

            set => SetProperty(ref _dataEmptyActionButtonClickCommand, value);
        }

        public string DataEmptyHint
        {
            get => _dataEmptyHint;

            set => SetProperty(ref _dataEmptyHint, value);
        }

        public bool IsDataEmpty
        {
            get => _isDataEmpty;

            set => SetProperty(ref _isDataEmpty, value);
        }

        public string LoadingHint
        {
            get => _loadingHint;

            set => SetProperty(ref _loadingHint, value);
        }

        public string MiddleMessage
        {
            get => _middleMessage;

            set => SetProperty(ref _middleMessage, value);
        }

        public bool ShowLoading
        {
            get => _showLoading;

            set => SetProperty(ref _showLoading, value);
        }
        #endregion
    }

    partial class PrimaryListBaseViewModel<TPrimaryModel>
    {
        #region Fields
        private MvxObservableCollection<TPrimaryModel> _primaryData;
        private IMvxCommand _itemClickCommand, _itemLongClickCommand;
        #endregion

        #region Properties
        public MvxObservableCollection<TPrimaryModel> PrimaryData
        {
            get => _primaryData;

            set => SetProperty(ref _primaryData, value);
        }

        public IMvxCommand PrimaryItemClickCommand
        {
            get => _itemClickCommand;

            set => SetProperty(ref _itemClickCommand, value);
        }

        public IMvxCommand PrimaryItemLongClickCommand
        {
            get => _itemLongClickCommand;

            set => SetProperty(ref _itemLongClickCommand, value);
        }
        #endregion
    }
}
