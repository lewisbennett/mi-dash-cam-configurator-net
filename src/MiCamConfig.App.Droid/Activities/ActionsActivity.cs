using Android.App;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using MiCamConfig.App.Core.ViewModels;
using MiCamConfig.App.Droid.Activities.List;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace MiCamConfig.App.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Label = "", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class ActionsActivity : PrimaryListBaseActivity<ActionsViewModel>
    {
        #region Properties
        /// <summary>
        /// Gets the layout resource ID for this Activity.
        /// </summary>
        public override int LayoutResID => Resource.Layout.activity_primary_list;
        #endregion

        #region Event Handlers
        public override void OnBackPressed()
        {
            base.OnBackPressed();

            FinishAffinity();
        }
        #endregion

        #region Protected Methods
        protected override RecyclerView.LayoutManager CreatePrimaryLayoutManager()
        {
            // TODO
            return new LinearLayoutManager(this);
        }
        #endregion
    }
}