using MiCamConfig.App.Core.Base;
using MiCamConfig.App.Core.Properties;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace MiCamConfig.App.Core.ViewModels
{
    public class ListViewModel<TModel> : BaseViewModel
        where TModel : class
    {
        #region Fields
        private string _dataEmptyMessage = Resources.MessageNothingToDisplay;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public MvxObservableCollection<TModel> Data { get; } = new MvxObservableCollection<TModel>();

        /// <summary>
        /// Gets whether the collection is currently empty.
        /// </summary>
        public bool IsDataEmpty => Data.Count < 1;

        /// <summary>
        /// Gets the command triggered when an item in the data is clicked.
        /// </summary>
        public IMvxCommand ItemClickCommand { get; private set; }

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
        /// <summary>
        /// Called when an item in the collection is clicked.
        /// </summary>
        /// <param name="item">The clicked item.</param>
        public virtual void OnItemClick(TModel item)
        {
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            ItemClickCommand = new MvxCommand<TModel>(OnItemClick);
        }
        #endregion
    }

    public class ListViewModel<TModel, TNavigationParams> : ListViewModel<TModel>, IMvxViewModel<TNavigationParams>
        where TModel : class
        where TNavigationParams : class
    {
        #region Lifecycle
        public virtual void Prepare(TNavigationParams parameter)
        {
        }
        #endregion
    }
}
