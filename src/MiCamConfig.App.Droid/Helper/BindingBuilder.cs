using MvvmCross.Platforms.Android.Binding;
using MvvmCross.Platforms.Android.Binding.Binders;

namespace MiCamConfig.App.Droid.Helper
{
    public class BindingBuilder : MvxAndroidBindingBuilder
    {
        #region Protected Methods
        protected override IMvxAndroidViewBinderFactory CreateAndroidViewBinderFactory()
        {
            return new ViewBinderFactory();
        }
        #endregion
    }
}