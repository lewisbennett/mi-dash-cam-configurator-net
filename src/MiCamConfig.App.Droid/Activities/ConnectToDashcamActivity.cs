using Android.App;
using Android.Views;
using MiCamConfig.App.Core.ViewModels;
using MiCamConfig.App.Droid.Activities.Base;
using MiCamConfig.App.Droid.Attributes;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace MiCamConfig.App.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Label = "", WindowSoftInputMode = SoftInput.AdjustPan)]
    [ActivityLayout(LayoutResourceId = Resource.Layout.activity_connect_to_dashcam)]
    public class ConnectToDashcamActivity : BaseActivity<ConnectToDashcamViewModel>
    {
        #region Event Handlers
        public override void OnBackPressed()
        {
            base.OnBackPressed();

            FinishAffinity();
        }
        #endregion
    }
}