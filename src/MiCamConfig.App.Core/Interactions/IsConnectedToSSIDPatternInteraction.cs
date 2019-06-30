using System.Text.RegularExpressions;

namespace MiCamConfig.App.Core.Interactions
{
    public class IsConnectedToSSIDPatternInteraction
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the mobile device is currently connected to the given network.
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Gets or sets the SSID pattern being checked.
        /// </summary>
        public Regex SSIDPattern { get; set; }
        #endregion
    }
}
