using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace MiDashCamConfigurator
{
    [Activity(MainLauncher = true, Theme = "@style/AppTheme.Splash", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(ConnectToDashCamActivity));
        }
    }
}