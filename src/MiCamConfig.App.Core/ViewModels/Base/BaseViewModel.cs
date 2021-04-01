using DialogMessaging.Interactions;
using MiCamConfig.App.Core.Properties;
using MiCamConfig.App.Core.Services;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MiCamConfig.App.Core.ViewModels.Base
{
    public abstract partial class BaseViewModel : MvxViewModel
    {
        #region Properties
        /// <summary>
        /// Gets the app's <see cref="ICoreService" />.
        /// </summary>
        public ICoreService CoreService { get; }
        #endregion

        #region Event Handlers
        private void BaseViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
        }
        #endregion

        #region Protected Methods
        protected virtual void AddEventHandlers()
        {
            PropertyChanged += BaseViewModel_PropertyChanged;
        }

        protected virtual object HandleException(Exception exception)
        {
            return exception switch
            {
                _ => new SnackbarConfig
                {
                    Message = Resources.MessageUnknownError
                }
            };
        }

        protected virtual void RemoveEventHandlers()
        {
            PropertyChanged -= BaseViewModel_PropertyChanged;
        }
        #endregion

        #region Lifecycle
        public override void ViewCreated()
        {
            base.ViewCreated();

            AddEventHandlers();
        }

        protected override void ReloadFromBundle(IMvxBundle state)
        {
            base.ReloadFromBundle(state);

            if (state != null && state.Data.TryGetValue(SavedInstanceStateID, out string instanceIdString)
                && long.TryParse(instanceIdString, out long instanceId)
                && CoreService.TryRetrieveInstanceState(instanceId, out IDictionary<string, object> savedState))
            {
                RestoreInstanceState(savedState);
            }
        }

        protected virtual void RestoreInstanceState(IDictionary<string, object> savedState)
        {
        }

        protected virtual void SaveInstanceState(IDictionary<string, object> state)
        {
        }

        protected override void SaveStateToBundle(IMvxBundle bundle)
        {
            base.SaveStateToBundle(bundle);

            var state = new Dictionary<string, object>();

            SaveInstanceState(state);

            if (state.Count > 0)
                bundle.Data[SavedInstanceStateID] = CoreService.SaveInstanceState(state).ToString();
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            base.ViewDestroy(viewFinishing);

            RemoveEventHandlers();
        }
        #endregion

        #region Constructors
        protected BaseViewModel(ICoreService coreService)
            : base()
        {
            CoreService = coreService;
        }
        #endregion

        #region Constant Values
        public const string SavedInstanceStateID = "saved_instance_state";
        #endregion
    }

    public abstract partial class BaseViewModel<TNavigationParams> : BaseViewModel, IMvxViewModel<TNavigationParams>
        where TNavigationParams : class
    {
        #region Lifecycle
        public abstract void Prepare(TNavigationParams parameter);
        #endregion

        #region Constructors
        protected BaseViewModel(ICoreService coreService)
            : base(coreService)
        {
        }
        #endregion
    }
}
