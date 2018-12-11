using Android.App;
using Android.Content;
using Android.Net.Wifi;
using System.Linq;
using System.Threading.Tasks;
using V4Fragment = Android.Support.V4.App.Fragment;
using MiDashCamConfigurator.Interfaces;

namespace MiDashCamConfigurator.Receivers
{
    public class WifiMonitor : BroadcastReceiver
    {
        private V4Fragment parent;

        public WifiMonitor(V4Fragment parent = null)
        {
            this.parent = parent;
        }

        public override async void OnReceive(Context context, Intent intent)
        {
            WifiManager wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);

            if ((context as IWifiMonitorListInflater) != null)
                ((IWifiMonitorListInflater)context).InflateList(wifiManager.ScanResults.ToList());

            else if ((parent as IWifiMonitorListInflater) != null && parent.IsVisible)
                ((IWifiMonitorListInflater)parent).InflateList(wifiManager.ScanResults.ToList());

            await Task.Delay(3000);
            wifiManager.StartScan();
        }
    }
}