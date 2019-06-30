using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using MiCamConfig.App.Core.Base;
using MiCamConfig.App.Droid.Base;
using MiCamConfig.App.Droid.Helper;
using MiCamConfig.App.Droid.TemplateSelectors;
using MiCamConfig.App.Droid.Views;

namespace MiCamConfig.App.Droid.Activities
{
    public class ListActivity<TViewModel> : BaseActivity<TViewModel>
        where TViewModel : BaseViewModel
    {
        #region Properties
        /// <summary>
        /// Gets this view's recycler view.
        /// </summary>
        public ElevationMvxRecyclerView RecyclerView { get; private set; }
        #endregion

        #region Lifecycle
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RecyclerView = FindViewById<ElevationMvxRecyclerView>(Resource.Id.recyclerview);

            RecyclerView.ElevationViews.Add(FindViewById<AppBarLayout>(Resource.Id.appbar));
            RecyclerView.SetLayoutManager(new GridLayoutManager(this, DimensionHelper.GridViewHorizontalCount));
            RecyclerView.ItemTemplateSelector = new BaseModelTemplateSelector();
        }
        #endregion
    }
}