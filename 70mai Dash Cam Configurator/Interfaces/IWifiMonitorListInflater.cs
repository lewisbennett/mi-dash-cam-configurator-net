using Android.Net.Wifi;
using System.Collections.Generic;

namespace MiDashCamConfigurator.Interfaces
{
    public interface IWifiMonitorListInflater
    {
        void InflateList(List<ScanResult> results);
    }
}