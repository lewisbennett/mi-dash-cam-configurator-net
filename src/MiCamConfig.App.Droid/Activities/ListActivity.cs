using Android.OS;
using AndroidX.RecyclerView.Widget;
using Google.Android.Material.AppBar;
using MiCamConfig.App.Core.ViewModels.Base;
using MiCamConfig.App.Droid.Activities.Base;
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
            RecyclerView.SetLayoutManager(new GridLayoutManager(this, 1));
            RecyclerView.ItemTemplateSelector = new BaseModelTemplateSelector();
        }
        #endregion
    }
}