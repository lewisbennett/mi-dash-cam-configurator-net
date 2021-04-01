using MiCamConfig.App.Core.Events;
using MiCamConfig.App.Core.Models.Base;
using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.ViewModels.List.Base
{
    public abstract partial class PrimaryListBaseViewModel : BaseViewModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether data is currently being loaded.
        /// </summary>
        public bool IsLoading { get; set; }
        #endregion

        #region Event Handlers
        protected virtual void OnDataEmptyActionButtonClicked()
        {
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(ShowLoading):
                    MiddleMessage = ShowLoading ? LoadingHint : DataEmptyHint;
                    return;

                default:
                    return;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads the initial page of data.
        /// </summary>
        public abstract void LoadInitialPage();

        /// <summary>
        /// Loads the next page of data.
        /// </summary>
        public abstract void LoadNextPage();
        #endregion

        #region Protected Methods
        protected virtual Task LoadInitialPageAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task LoadNextPageAsync()
        {
            return Task.CompletedTask;
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            DataEmptyActionButtonClickCommand = new MvxCommand(OnDataEmptyActionButtonClicked);
        }
        #endregion

        #region Constructors
        protected PrimaryListBaseViewModel(ICoreService coreService)
            : base(coreService)
        {
        }
        #endregion
    }

    public abstract partial class PrimaryListBaseViewModel<TPrimaryModel> : PrimaryListBaseViewModel
        where TPrimaryModel : class
    {
        #region Events
        public event EventHandler<ItemClickedEventArgs<TPrimaryModel>> PrimaryItemClicked;
        public event EventHandler<ItemClickedEventArgs<TPrimaryModel>> PrimaryItemLongClicked;
        #endregion

        #region Event Handlers
        protected virtual void OnPrimaryDataCollectionChanged(NotifyCollectionChangedAction action, int oldStartingIndex, IList oldItems, int newStartingIndex, IList newItems)
        {
            IsDataEmpty = CalculateIsDataEmpty();
        }

        protected virtual void OnPrimaryItemClicked(TPrimaryModel item)
        {
            PrimaryItemClicked?.Invoke(this, new ItemClickedEventArgs<TPrimaryModel>(item));
        }

        protected virtual void OnPrimaryItemLongClicked(TPrimaryModel item)
        {
            PrimaryItemLongClicked?.Invoke(this, new ItemClickedEventArgs<TPrimaryModel>(item));
        }

        private void PrimaryData_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPrimaryDataCollectionChanged(e.Action, e.OldStartingIndex, e.OldItems, e.NewStartingIndex, e.NewItems);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads the initial page of data.
        /// </summary>
        public override void LoadInitialPage()
        {
            if (IsLoading)
                return;

            IsLoading = true;

            ShowLoading = IsDataEmpty;

            CoreService.ExecuteTaskAsync(LoadInitialPageAsync, exceptionHandler: HandleException).ContinueWith((task) =>
            {
                IsLoading = ShowLoading = false;
            });
        }

        /// <summary>
        /// Loads the next page of data.
        /// </summary>
        public override void LoadNextPage()
        {
            if (IsLoading)
                return;

            IsLoading = true;

            CoreService.ExecuteTaskAsync(LoadNextPageAsync, exceptionHandler: HandleException).ContinueWith((task) =>
            {
                IsLoading = false;
            });
        }
        #endregion

        #region Protected Methods
        protected override void AddEventHandlers()
        {
            base.AddEventHandlers();

            PrimaryData.CollectionChanged += PrimaryData_CollectionChanged;
        }

        protected virtual bool CalculateIsDataEmpty()
        {
            return PrimaryData.Count < 1;
        }

        protected override void RemoveEventHandlers()
        {
            base.RemoveEventHandlers();

            PrimaryData.CollectionChanged -= PrimaryData_CollectionChanged;
        }
        #endregion

        #region Lifecycle
        public override void Prepare()
        {
            base.Prepare();

            PrimaryData = new MvxObservableCollection<TPrimaryModel>();

            PrimaryItemClickCommand = new MvxCommand<TPrimaryModel>(OnPrimaryItemClicked);
            PrimaryItemLongClickCommand = new MvxCommand<TPrimaryModel>(OnPrimaryItemLongClicked);

            IsDataEmpty = true;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            LoadInitialPage();
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            base.ViewDestroy(viewFinishing);

            if (viewFinishing)
            {
                foreach (var item in PrimaryData)
                {
                    if (item is BaseModel baseModel)
                        baseModel.RemoveEventHandlers();
                }
            }
        }
        #endregion

        #region Constructors
        protected PrimaryListBaseViewModel(ICoreService coreService)
            : base(coreService)
        {
        }
        #endregion
    }

    public abstract class PrimaryListBaseViewModel<TPrimaryModel, TNavigationParams> : PrimaryListBaseViewModel<TPrimaryModel>, IMvxViewModel<TNavigationParams>
        where TPrimaryModel : class
        where TNavigationParams : class
    {
        #region Lifecycle
        public abstract void Prepare(TNavigationParams parameter);
        #endregion

        #region Constructors
        protected PrimaryListBaseViewModel(ICoreService coreService)
            : base(coreService)
        {
        }
        #endregion
    }
}
