using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using MiDashCamConfigurator.Fragments;
using V4Fragment = Android.Support.V4.App.Fragment;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using V4FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

namespace MiDashCamConfigurator
{
    [Activity(Label = "@string/connect_to_dash_cam", Theme = "@style/AppTheme.NoActionBar")]
    public class ConnectToDashCamActivity : AppCompatActivity
    {
        public V4Fragment CheckingConnectionFragment = new CheckingConnectionFragment();
        public V4Fragment NotConnectedFragment = new NotConnectedFragment();
        public V4Fragment ConnectingFragment = new ConnectingFragment();

        private V4Fragment _currentFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityConnectToDashCam);

            Constants.ActiveCoordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.coordinator_layout);

            // setup toolbar
            V7Toolbar toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // add all fragments used by this activity to the stack and hide all but the first one
            SupportFragmentManager.BeginTransaction()
                .Add((Resource.Id.framelayout), CheckingConnectionFragment)
                .Add((Resource.Id.framelayout), NotConnectedFragment).Hide(NotConnectedFragment)
                .Add((Resource.Id.framelayout), ConnectingFragment).Hide(ConnectingFragment)
                .Commit();

            _currentFragment = CheckingConnectionFragment;
        }

        protected override void OnResume()
        {
            base.OnResume();

            Constants.ActiveCoordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.coordinator_layout);
        }

        public void SetFragment(V4Fragment fragment)
        {
            // don't proceed if the fragment is already in view
            if (fragment.IsVisible)
                return;

            // replace the fragment
            V4FragmentTransaction transaction = SupportFragmentManager.BeginTransaction();

            if (_currentFragment != null)
                transaction.Hide(_currentFragment);

            transaction.Show(fragment);
            transaction.Commit();

            if (fragment.View != null)
                fragment.OnResume();

            // update the current fragment
            _currentFragment = fragment;
        }
    }
}