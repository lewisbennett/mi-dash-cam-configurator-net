using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace MiCamConfig.App.Droid.Activities
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/AppTheme.Splash")]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
    }
}