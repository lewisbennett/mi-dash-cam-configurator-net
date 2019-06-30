using Android.App;
using Android.Content;
using Android.Net.Wifi;
using MiCamConfig.App.Core.Interactions;
using MvvmCross.Base;
using MvvmCross.ViewModels;
using System.Text.RegularExpressions;

namespace MiCamConfig.App.Droid.Services
{
    public class WifiScanningService : IWifiScanningService
    {
        #region Fields
        private IMvxInteraction<IsConnectedToSSIDInteraction> _isConnectedToSSIDInteraction;
        private IMvxInteraction<IsConnectedToSSIDPatternInteraction> _isConnectedToSSIDPatternInteraction;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current SSID that the mobile device is conncted to.
        /// </summary>
        public string CurrentSSID
        {
            get
            {
                var currentSsid = WifiManager.ConnectionInfo.SSID;

                if (currentSsid.StartsWith("\""))
                    currentSsid = currentSsid.Remove(0, 1);

                if (currentSsid.EndsWith("\""))
                    currentSsid = currentSsid.Remove(currentSsid.Length - 1, 1);

                return currentSsid;
            }
        }

        /// <summary>
        /// Gets or sets the interaction to check if the mobile device is connected to a given network.
        /// </summary>
        public IMvxInteraction<IsConnectedToSSIDInteraction> IsConnectedToSSIDInteraction
        {
            get => _isConnectedToSSIDInteraction;

            set
            {
                if (_isConnectedToSSIDInteraction != null)
                    _isConnectedToSSIDInteraction.Requested -= IsConnectedToSSIDInteraction_Requested;

                _isConnectedToSSIDInteraction = value;
                _isConnectedToSSIDInteraction.Requested += IsConnectedToSSIDInteraction_Requested;
            }
        }

        /// <summary>
        /// Gets or sets the interaction to check if the mobile device is connected to a given network from a pattern.
        /// </summary>
        public IMvxInteraction<IsConnectedToSSIDPatternInteraction> IsConnectedToSSIDPatternInteraction
        {
            get => _isConnectedToSSIDPatternInteraction;

            set
            {
                if (_isConnectedToSSIDPatternInteraction != null)
                    _isConnectedToSSIDPatternInteraction.Requested -= IsConnectedToSSIDPatternInteraction_Requested;

                _isConnectedToSSIDPatternInteraction = value;
                _isConnectedToSSIDPatternInteraction.Requested += IsConnectedToSSIDPatternInteraction_Requested;
            }
        }

        /// <summary>
        /// Gets the WiFi manager service.
        /// </summary>
        public WifiManager WifiManager { get; } = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
        #endregion

        #region Event Handlers
        private void IsConnectedToSSIDInteraction_Requested(object sender, MvxValueEventArgs<IsConnectedToSSIDInteraction> e)
        {
            e.Value.IsConnected = IsConnectedToSSID(e.Value.SSID);
        }

        private void IsConnectedToSSIDPatternInteraction_Requested(object sender, MvxValueEventArgs<IsConnectedToSSIDPatternInteraction> e)
        {
            e.Value.IsConnected = IsConnectedToSSID(e.Value.SSIDPattern);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Checks whether the mobile device is currently connected to a given network.
        /// </summary>
        /// <param name="ssid">The SSID of the network to check.</param>
        public bool IsConnectedToSSID(string ssid)
        {
            if (string.IsNullOrWhiteSpace(ssid))
                return false;

            return ssid.Equals(CurrentSSID);
        }

        /// <summary>
        /// Checks whether the mobile device is currently connected to a given network from a pattern.
        /// </summary>
        /// <param name="ssid">The SSID pattern of the network to check.</param>
        public bool IsConnectedToSSID(Regex ssidPattern)
        {
            if (ssidPattern == null)
                return false;

            return ssidPattern.Match(CurrentSSID).Success;
        }
        #endregion
    }
}