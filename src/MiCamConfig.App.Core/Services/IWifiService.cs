using MiCamConfig.App.Core.Interactions;
using MvvmCross.ViewModels;
using System.Text.RegularExpressions;

namespace MiCamConfig.App.Core.Services
{
    public interface IWifiService
    {
        bool IsConnectedToSSID(string ssid);
        bool IsConnectedToSSID(Regex ssidPattern);
        MvxInteraction<IsConnectedToSSIDInteraction> IsConnectedToSSIDInteraction { get; }
        MvxInteraction<IsConnectedToSSIDPatternInteraction> IsConnectedToSSIDPatternInteraction { get; }
    }
}
