using Android.Net.Wifi;
using MiCamConfig.App.Core.Interactions;
using MvvmCross.ViewModels;
using System.Text.RegularExpressions;

namespace MiCamConfig.App.Droid.Services
{
    public interface IWifiScanningService
    {
        string CurrentSSID { get; }
        bool IsConnectedToSSID(string ssid);
        bool IsConnectedToSSID(Regex ssidPattern);
        IMvxInteraction<IsConnectedToSSIDInteraction> IsConnectedToSSIDInteraction { get; }
        IMvxInteraction<IsConnectedToSSIDPatternInteraction> IsConnectedToSSIDPatternInteraction { get; }
        WifiManager WifiManager { get; }
    }
}