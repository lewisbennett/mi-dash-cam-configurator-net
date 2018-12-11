using Android.App;
using Android.Content;
using Android.Net.Wifi;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiDashCamConfigurator.Helper
{
    public class DashCam
    {
        public static Regex SSID = new Regex("70mai_d01_[0-9a-zA-Z]{4}");

        public static bool IsConnected()
        {
            string currentSSID = ((WifiManager)Application.Context.GetSystemService(Context.WifiService)).ConnectionInfo.SSID;

            if (currentSSID != null)
            {
                // remove quotation marks from start and finish of string
                currentSSID = currentSSID.Remove(0, 1);
                currentSSID = currentSSID.Remove(currentSSID.Length - 1, 1);    // -1 to correct for 0 index and final character of string

                return SSID.Match(currentSSID).Success;
            }
            else
                return false;
        }

        public async static Task ConnectToDashCam(string ssid)
        {
            // get WifiManager
            WifiManager wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);

            // create a new WifiConfiguration and assign SSID and password
            WifiConfiguration wifiConfig = new WifiConfiguration { Ssid = $"\"{ssid}\"" };
            wifiConfig.AllowedKeyManagement.Set((int)KeyManagementType.None);

            wifiManager.AddNetwork(wifiConfig);

            List<WifiConfiguration> configs = wifiManager.ConfiguredNetworks.ToList();

            // run this up to 5 times
            for (int i = 0; i < 5; i++)
            {
                // if we're connected to the correct network, break the loop
                if (wifiManager.ConnectionInfo.SSID.Equals(wifiConfig.Ssid))
                    break;

                else
                {
                    wifiManager.Disconnect();   // force disconnect

                    // enable the network that we want to connect to and tell WifiManager that we want to reconnect to it
                    wifiManager.EnableNetwork(configs.FirstOrDefault(c => c.Ssid.Equals(wifiConfig.Ssid)).NetworkId, true);

                    wifiManager.Reconnect();    // force reconnect

                    // mandatory wait for 5 seconds to allow the connection to take place
                    await Task.Delay(5000);
                }
            }
        }
    }
}