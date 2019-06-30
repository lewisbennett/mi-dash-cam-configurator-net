using MiCamConfig.App.Core.Interactions;
using MvvmCross.ViewModels;
using System.Text.RegularExpressions;

namespace MiCamConfig.App.Core.Services
{
    public class WifiService : IWifiService
    {
        #region Properties
        /// <summary>
        /// Gets the interaction to check if the mobile device is connected to a given network.
        /// </summary>
        public MvxInteraction<IsConnectedToSSIDInteraction> IsConnectedToSSIDInteraction { get; } = new MvxInteraction<IsConnectedToSSIDInteraction>();

        /// <summary>
        /// Gets the interaction to check if the mobile device is connected to a given network from a pattern.
        /// </summary>
        public MvxInteraction<IsConnectedToSSIDPatternInteraction> IsConnectedToSSIDPatternInteraction { get; } = new MvxInteraction<IsConnectedToSSIDPatternInteraction>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Checks if the mobile device is currently connected to a given network.
        /// </summary>
        /// <param name="ssid">The SSID to check.</param>
        public bool IsConnectedToSSID(string ssid)
        {
            var interaction = new IsConnectedToSSIDInteraction { SSID = ssid };

            IsConnectedToSSIDInteraction.Raise(interaction);

            return interaction.IsConnected;
        }

        /// <summary>
        /// Checks if the mobile device is currently connected to a given network.
        /// </summary>
        /// <param name="ssidPattern">The pattern of the SSID to check.</param>
        public bool IsConnectedToSSID(Regex ssidPattern)
        {
            var interaction = new IsConnectedToSSIDPatternInteraction { SSIDPattern = ssidPattern };

            IsConnectedToSSIDPatternInteraction.Raise(interaction);

            return interaction.IsConnected;
        }
        #endregion
    }
}
