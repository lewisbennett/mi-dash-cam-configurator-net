using DialogMessaging.Interactions;
using MiCamConfig.App.Core.Properties;
using MvvmCross.ViewModels;
using System;
using System.ComponentModel;

namespace MiCamConfig.App.Core.Models.Base
{
    public abstract class BaseModel : MvxNotifyPropertyChanged
    {
        #region Event Handlers
        private void BaseModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Remove the model's event handlers, if any.
        /// </summary>
        public virtual void RemoveEventHandlers()
        {
            PropertyChanged -= BaseModel_PropertyChanged;
        }
        #endregion

        #region Protected Methods
        protected virtual object HandleException(Exception exception)
        {
            return new SnackbarConfig
            {
                Message = Resources.MessageUnknownError
            };
        }
        #endregion

        #region Constructors
        protected BaseModel()
            : base()
        {
            PropertyChanged += BaseModel_PropertyChanged;
        }
        #endregion
    }
}
