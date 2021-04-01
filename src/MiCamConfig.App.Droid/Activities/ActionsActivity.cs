using Android.App;
using Android.Views;
using MiCamConfig.App.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace MiCamConfig.App.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Label = "", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class ActionsActivity : ListActivity<ActionsViewModel>
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