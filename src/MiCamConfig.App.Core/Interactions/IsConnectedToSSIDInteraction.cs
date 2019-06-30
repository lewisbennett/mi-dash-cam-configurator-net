namespace MiCamConfig.App.Core.Interactions
{
    public class IsConnectedToSSIDInteraction
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the mobile device is currently connected to the given network.
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Gets or sets the SSID being checked.
        /// </summary>
        public string SSID { get; set; }
        #endregion
    }
}
