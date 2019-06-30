using Android.Content;
using Android.Support.V7.App;
using MiCamConfig.App.Core.Interactions;
using MvvmCross.Base;
using MvvmCross.ViewModels;

namespace MiCamConfig.App.Droid.Services
{
    public class MessagingService : IMessagingService
    {
        #region Fields
        public IMvxInteraction<AlertConfig> _alertInteraction;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the alert interaction.
        /// </summary>
        public IMvxInteraction<AlertConfig> AlertInteraction
        {
            get => _alertInteraction;

            set
            {
                if (_alertInteraction != null)
                    _alertInteraction.Requested -= AlertInteraction_Requested;

                _alertInteraction = value;
                _alertInteraction.Requested += AlertInteraction_Requested;
            }
        }

        /// <summary>
        /// Gets or sets the current activity contetxt.
        /// </summary>
        public Context Context { get; set; }
        #endregion

        #region Event Handlers
        private void AlertInteraction_Requested(object sender, MvxValueEventArgs<AlertConfig> e)
        {
            Alert(e.Value);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public void Alert(AlertConfig config)
        {
            if (Context == null)
                return;

            if (!(Context is AppCompatActivity activity))
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
    }
}