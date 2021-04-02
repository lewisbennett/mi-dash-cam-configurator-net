using Android.App;
using Android.Runtime;
using DialogMessaging;
using DialogMessaging.Interactions;
using MvvmCross.Platforms.Android.Views;
using System;

namespace MiCamConfig.App.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, Core.App>
    {
        #region Lifecycle
        public override void OnCreate()
        {
            base.OnCreate();

            ConfigureDialogMessaging();
        }
        #endregion

        #region Constructors
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        #endregion

        #region Private Methods
        private void ConfigureDialogMessaging()
        {
            MessagingService.Init(this);

            ActionSheetBottomConfigDefaults.Cancelable = true;

            ActionSheetConfigDefaults.Cancelable = true;

            AlertConfigDefaults.Cancelable = true;
        }
        #endregion
    }
}