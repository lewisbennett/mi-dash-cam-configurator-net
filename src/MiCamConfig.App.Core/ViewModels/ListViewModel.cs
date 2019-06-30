using MiCamConfig.App.Core.Base;
using MiCamConfig.App.Core.Properties;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.Specialized;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ListViewModel<TModel> : BaseViewModel
        where TModel : class
    {
        #region Fields
        private MvxObservableCollection<TModel> _data = new MvxObservableCollection<TModel>();
        private IMvxCommand _itemClickCommand;
        private string _dataEmptyMessage = Resources.MessageNothingToDisplay;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public MvxObservableCollection<TModel> Data
        {
            get => _data;

            set
            {
                _data = value;
                RaisePropertyChanged(() => Data);
            }
        }

        /// <summary>
        /// Gets the command triggered when an item in the data is clicked.
        /// </summary>
        public IMvxCommand ItemClickCommand
        {
            get
            {
                _itemClickCommand = _itemClickCommand ?? new MvxCommand<TModel>(OnItemClick);

                return _itemClickCommand;
            }
        }

        /// <summary>
        /// Gets or sets the message displayed when the data is empty.
        /// </summary>
        public virtual string DataEmptyMessage
        {
            get => _dataEmptyMessage;

            set
            {
                _dataEmptyMessage = value;
                RaisePropertyChanged(() => DataEmptyMessage);
            }
        }
        #endregion

        #region Event Handlers
        private void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        public virtual void OnItemClick(TModel item)
        {
        }
        #endregion

        #region Lifecycle
        public override void ViewAppearing()
        {
            base.ViewAppearing();

            Data.CollectionChanged += Data_CollectionChanged;
        }

        public override void ViewDisappearing()
        {
            base.ViewDisappearing();

            Data.CollectionChanged -= Data_CollectionChanged;
        }
        #endregion
    }
}
