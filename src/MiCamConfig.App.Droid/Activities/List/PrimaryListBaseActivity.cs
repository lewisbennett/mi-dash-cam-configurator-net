using Android.OS;
using AndroidX.RecyclerView.Widget;
using MiCamConfig.App.Core.ViewModels.Base;
using MiCamConfig.App.Droid.Activities.Base;
using MiCamConfig.App.Droid.Views;
using MvvmCross.Views;

namespace MiCamConfig.App.Droid.Activities.List
{
    public abstract partial class PrimaryListBaseActivity : BaseActivity
    {
        #region Protected Methods
        protected override void AddEventHandlers()
        {
            base.AddEventHandlers();

            if (PrimaryRecyclerView is ElevationMvxRecyclerView elevationMvxRecyclerView)
                elevationMvxRecyclerView.RegisterElevationView(AppBarLayout);
        }

        protected virtual int CalculateHorizontalItemCount(float nominalWidth)
        {
            // TODO
            return 1;
        }

        protected abstract RecyclerView.LayoutManager CreatePrimaryLayoutManager();

        protected override void RemoveEventHandlers()
        {
            base.RemoveEventHandlers();

            if (PrimaryRecyclerView is ElevationMvxRecyclerView elevationMvxRecyclerView)
                elevationMvxRecyclerView.UnregisterElevationView(AppBarLayout);
        }
        #endregion

        #region Lifecycle
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            PrimaryRecyclerView = FindViewById<RecyclerView>(Resource.Id.primaryrecyclerview);

            PrimaryRecyclerView.Setup(CreatePrimaryLayoutManager());
        }
        #endregion
    }

    public abstract class PrimaryListBaseActivity<TViewModel> : PrimaryListBaseActivity, IMvxView<TViewModel>
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