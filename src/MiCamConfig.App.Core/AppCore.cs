using System.Text.RegularExpressions;

namespace MiCamConfig.App.Core
{
    public class AppCore
    {
        #region Properties
        /// <summary>
        /// Gets the Regex that represents the SSID of a compatible dashcam.
        /// </summary>
        public static Regex DashcamSSID { get; } = new Regex("70mai_d[0-9]{2}_[0-9a-zA-Z]{4}");
        #endregion
    }
}
