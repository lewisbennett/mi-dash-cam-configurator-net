using Android.OS;
using Android.Views;
using MiDashCamConfigurator.Helper;
using System;
using System.Threading.Tasks;
using V4Fragment = Android.Support.V4.App.Fragment;

namespace MiDashCamConfigurator.Fragments
{
    public class CheckingConnectionFragment : V4Fragment
    {
        private ConnectToDashCamActivity _parent;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if ((Activity as ConnectToDashCamActivity) != null)
                _parent = (ConnectToDashCamActivity)Activity;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.FragmentCheckingConnection, null);
            return view;
        }

        public override void OnResume()
        {
            base.OnResume();

            CheckConnectionAsync();
        }

        private async Task CheckConnectionAsync()
        {
            // mandatory wait just in case we're in the process of connecting
            await Task.Delay(TimeSpan.FromSeconds(2));

            if (DashCam.IsConnected())
                CustomMessaging.ShowSnackbar("Connected!");
            else
                _parent.SetFragment(_parent.NotConnectedFragment);
        }
    }
}