using Android;
using Android.Content;
using Android.Content.PM;
using Android.Net.Wifi;
using Android.OS;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using MiDashCamConfigurator.Helper;
using MiDashCamConfigurator.Interfaces;
using MiDashCamConfigurator.Receivers;
using System.Collections.Generic;
using System.Linq;
using V4Fragment = Android.Support.V4.App.Fragment;

namespace MiDashCamConfigurator.Fragments
{
    public class ConnectingFragment : V4Fragment, IWifiMonitorListInflater
    {
        private bool _isConnecting = false;

        private int _retries = 0;

        private ConnectToDashCamActivity _parent;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if ((Activity as ConnectToDashCamActivity) != null)
                _parent = (ConnectToDashCamActivity)Activity;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.FragmentConnecting, null);
            return view;
        }

        public override void OnResume()
        {
            base.OnResume();

            _retries = 0;

            Context.RegisterReceiver(new WifiMonitor(this), new IntentFilter(WifiManager.ScanResultsAvailableAction));
            ((WifiManager)Context.GetSystemService(Context.WifiService)).StartScan();

            // ask for location permission if it hasn't already been granted
            if (ContextCompat.CheckSelfPermission(Context, Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
            {
                Toast.MakeText(Context, GetString(Resource.String.error_no_location_access), ToastLength.Long).Show();
                Activity.RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation }, Constants.PermissionAccessCoarseLocation);
            }
        }

        public async void InflateList(List<ScanResult> results)
        {
            if (!_isConnecting && results.Any(r => DashCam.SSID.Match(r.Ssid).Success))
            {
                _isConnecting = true;

                await DashCam.ConnectToDashCam(results.FirstOrDefault(r => DashCam.SSID.Match(r.Ssid).Success).Ssid);

                _parent.SetFragment(_parent.CheckingConnectionFragment);

                return;
            }

            if (_retries > 4)
            {
                _parent.SetFragment(_parent.NotConnectedFragment);
                return;
            }

            _retries++;
        }
    }
}