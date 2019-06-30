using MiCamConfig.App.Core.Interactions;
using MvvmCross.ViewModels;

namespace MiCamConfig.App.Core.Services
{
    public class MessagingService : IMessagingService
    {
        #region Properties
        /// <summary>
        /// Gets the alert interaction.
        /// </summary>
        public MvxInteraction<AlertConfig> AlertInteraction { get; } = new MvxInteraction<AlertConfig>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public void Alert(AlertConfig config)
        {
            AlertInteraction.Raise(config);
        }
        #endregion
    }
}
