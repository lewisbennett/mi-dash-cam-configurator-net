using Android.Content;
using Android.Support.V7.App;
using MiCamConfig.App.Core.Interactions;
using MiCamConfig.App.Core.Services;

namespace MiCamConfig.App.Droid.Services
{
    public class MessagingService : IMessagingService
    {
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
        #endregion

        #region Static Properties
        public static Context Context { get; set; }
        #endregion
    }
}