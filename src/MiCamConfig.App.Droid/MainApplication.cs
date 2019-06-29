using Android.App;
using Android.Runtime;
using MvvmCross.Droid.Support.V7.AppCompat;
using System;

namespace MiCamConfig.App.Droid
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<Setup, Core.App>
    {
        #region Constructors
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        #endregion
    }
}