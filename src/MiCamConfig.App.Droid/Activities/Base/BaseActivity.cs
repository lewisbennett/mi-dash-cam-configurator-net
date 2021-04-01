using Android.OS;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.AppBar;
using MiCamConfig.App.Core.ViewModels.Base;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Views;

namespace MiCamConfig.App.Droid.Activities.Base
{
    public abstract partial class BaseActivity : MvxActivity
    {
        #region Properties
        /// <summary>
        /// Gets the layout resource ID for this Activity.
        /// </summary>
        public abstract int LayoutResID { get; }
        #endregion

        #region Protected Methods
        protected virtual void AddEventHandlers()
        {
        }

        protected virtual void RemoveEventHandlers()
        {
        }
        #endregion

        #region Lifecycle
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(LayoutResID);

            AppBarLayout = FindViewById<AppBarLayout>(Resource.Id.appbarlayout);
            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (Toolbar != null)
                SetSupportActionBar(Toolbar);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);

            AddEventHandlers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            RemoveEventHandlers();
        }
        #endregion
    }

    public abstract class BaseActivity<TViewModel> : BaseActivity, IMvxView<TViewModel>
        where TViewModel : BaseViewModel
    {
        #region Properties
        public new TViewModel ViewModel
        {
            get => base.ViewModel as TViewModel;

            set => base.ViewModel = value;
        }
        #endregion
    }
}