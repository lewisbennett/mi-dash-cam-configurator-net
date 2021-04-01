using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using System;

namespace MiCamConfig.App.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, Core.App>
    {
        #region Constructors
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        #endregion
    }
}