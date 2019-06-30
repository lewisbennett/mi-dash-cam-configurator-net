using Android.App;
using Android.Views;
using MiCamConfig.App.Core.ViewModels;
using MiCamConfig.App.Droid.Attributes;
using MiCamConfig.App.Droid.Base;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace MiCamConfig.App.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Label = "", WindowSoftInputMode = SoftInput.AdjustPan)]
    [ActivityLayout(LayoutResourceId = Resource.Layout.activity_connect_to_dashcam)]
    public class ConnectToDashcamActivity : BaseActivity<ConnectToDashcamViewModel>
    {
        #region Lifecycle
        protected override void OnResume()
        {
            base.OnResume();

            if (!PermissionsService.HasAskedForPermissions)
                PermissionsService.AskForPermissions(this);
        }
        #endregion
    }
}