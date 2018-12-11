using Android.OS;
using Android.Views;
using Android.Widget;
using V4Fragment = Android.Support.V4.App.Fragment;

namespace MiDashCamConfigurator.Fragments
{
    public class NotConnectedFragment : V4Fragment
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
            View view = inflater.Inflate(Resource.Layout.FragmentNotConnected, null);

            // register click handlers
            view.FindViewById<Button>(Resource.Id.button_retry).Click += (s, e) => _parent.SetFragment(_parent.CheckingConnectionFragment);
            view.FindViewById<Button>(Resource.Id.button_connect_automatically).Click += (s, e) => _parent.SetFragment(_parent.ConnectingFragment);

            return view;
        }
    }
}