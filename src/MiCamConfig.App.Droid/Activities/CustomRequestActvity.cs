using Android.App;
using Android.OS;
using Android.Views;
using MiCamConfig.App.Core.ViewModels;
using MiCamConfig.App.Droid.Activities.Base;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace MiCamConfig.App.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Label = "", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class CustomRequestActivity : BaseActivity<CustomRequestViewModel>
    {
        #region Properties
        /// <summary>
        /// Gets the layout resource ID for this Activity.
        /// </summary>
        public override int LayoutResID => Resource.Layout.activity_custom_request;
        #endregion

        #region Event Handlers
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
        #endregion

        #region Lifecycle
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(true);
        }
        #endregion
    }
}