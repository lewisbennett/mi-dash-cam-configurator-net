﻿using Android.App;
using Android.OS;
using DialogMessaging;
using MvvmCross.Platforms.Android.Views;

namespace MiCamConfig.App.Droid.Activities
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/AppTheme.Splash")]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
        #region Lifecycle
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ConfigureDialogMessaging();
        }
        #endregion

        #region Private Methods
        private void ConfigureDialogMessaging()
        {
            MessagingService.Init(this);

#if DEBUG
            MessagingService.VerboseLogging = true;
#endif
        }
        #endregion
    }
}