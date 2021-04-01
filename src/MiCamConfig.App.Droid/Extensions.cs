using AndroidX.RecyclerView.Widget;
using MiCamConfig.App.Droid.TemplateSelectors;
using MvvmCross.DroidX.RecyclerView;

namespace MiCamConfig.App.Droid
{
    public static class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Applies the correct item template selector and layout manager.
        /// </summary>
        public static void Setup(this RecyclerView recyclerView, RecyclerView.LayoutManager layoutManager)
        {
            if (recyclerView is MvxRecyclerView mvxRecyclerView)
                mvxRecyclerView.ItemTemplateSelector = new BaseModelItemTemplateSelector();

            recyclerView.SetLayoutManager(layoutManager);
        }
        #endregion
    }
}