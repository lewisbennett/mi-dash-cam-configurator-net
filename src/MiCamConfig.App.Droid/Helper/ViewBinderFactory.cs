using MvvmCross.Platforms.Android.Binding.Binders;

namespace MiCamConfig.App.Droid.Helper
{
    public class ViewBinderFactory : IMvxAndroidViewBinderFactory
    {
        #region Public Methods
        public IMvxAndroidViewBinder Create(object source)
        {
            return new ViewBinder(source);
        }
        #endregion
    }
}