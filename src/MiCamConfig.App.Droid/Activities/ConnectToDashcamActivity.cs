﻿using Android.App;
using Android.Views;
using MiCamConfig.App.Core.ViewModels;
using MiCamConfig.App.Droid.Activities.Base;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace MiCamConfig.App.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Label = "", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class ConnectToDashcamActivity : BaseActivity<ConnectToDashcamViewModel>
    {
        #region Properties
        /// <summary>
        /// Gets the layout resource ID for this Activity.
        /// </summary>
        public override int LayoutResID => Resource.Layout.activity_connect_to_dashcam;
        #endregion

        #region Event Handlers
        public override void OnBackPressed()
        {
            base.OnBackPressed();

            FinishAffinity();
        }
        #endregion
    }
}