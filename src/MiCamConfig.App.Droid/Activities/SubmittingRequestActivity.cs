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
    [ActivityLayout(EnableBackButton = true, LayoutResourceId = Resource.Layout.activity_submitting_request)]
    public class SubmittingRequestActivity : BaseActivity<SubmittingRequestViewModel>
    {
        #region Properties
        /// <summary>
        /// Gets the layout resource ID for this Activity.
        /// </summary>
        public override int LayoutResID => Resource.Layout.activity_submitting_request;
        #endregion
    }
}