using Android.Content;
using Android.Support.V4.App;
using Android.Support.V7.App;
using MiCamConfig.App.Core.Interactions;
using MiCamConfig.App.Core.Services;
using MiCamConfig.App.Droid.DialogFragments;
using System;

namespace MiCamConfig.App.Droid.Services
{
    public class MessagingService : IMessagingService
    {
        #region Fields
        private DialogFragment _loadingDialog;
        #endregion

        #region Public Methods
        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public void Alert(AlertConfig config)
        {
            if (Context == null || !(Context is AppCompatActivity activity))
                return;

            var builder = new AlertDialog.Builder(Context);

            if (!string.IsNullOrWhiteSpace(config.Title))
                builder.SetTitle(config.Title);

            if (!string.IsNullOrWhiteSpace(config.Message))
                builder.SetMessage(config.Message);

            if (!string.IsNullOrWhiteSpace(config.OkButtonText))
                builder.SetPositiveButton(config.OkButtonText, (s, e) => config.OkButtonClickAction?.Invoke());

            if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                builder.SetNegativeButton(config.CancelButtonText, (s, e) => config.CancelButtonClickAction?.Invoke());

            builder.Create().Show();
        }

        /// <summary>
        /// Hides the loading wheel from the user, if any.
        /// </summary>
        public void HideLoading()
        {
            if (_loadingDialog == null || _loadingDialog.IsStateSaved || !(Context is AppCompatActivity activity))
                return;

            activity.RunOnUiThread(() =>
            {
                try
                {
                    _loadingDialog.Dismiss();
                }
                catch (Exception) { }
            });
        }

        /// <summary>
        /// Displays a loading wheel to the user.
        /// </summary>
        /// <param name="message">The loading message.</param>
        public void ShowLoading(string message)
        {
            if (Context == null || !(Context is AppCompatActivity activity) || (_loadingDialog != null && _loadingDialog.IsVisible))
                return;

            activity.RunOnUiThread(() =>
            {
                _loadingDialog = new LoadingDialogFragment(message);
                _loadingDialog.Show(activity.SupportFragmentManager, "dialog_loading");
            });
        }
        #endregion

        #region Static Properties
        public static Context Context { get; set; }
        #endregion
    }
}