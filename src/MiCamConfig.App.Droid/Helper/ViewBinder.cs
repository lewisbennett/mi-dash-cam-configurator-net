using Android.Content;
using Android.Util;
using Android.Views;
using DialogMessaging;
using MvvmCross.Platforms.Android.Binding.Binders;

namespace MiCamConfig.App.Droid.Helper
{
    public class ViewBinder : MvxAndroidViewBinder
    {
        #region Public Methods
        public override void BindView(View view, Context context, IAttributeSet attrs)
        {
            base.BindView(view, context, attrs);

            MessagingService.ViewManager.OnViewInflated(view, attrs);
        }
        #endregion

        #region Constructors
        public ViewBinder(object source)
            : base(source)
        {
        }
        #endregion
    }
}