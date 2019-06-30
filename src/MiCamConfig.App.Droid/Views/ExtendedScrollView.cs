using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using System;

namespace MiCamConfig.App.Droid.Views
{
    public class ExtendedScrollView : ScrollView
    {
        #region Event Handlers
        public virtual void OnScrollChanged(int dx, int dy)
        {
        }

        private void ExtendedScrollView_ScrollChange(object sender, ScrollChangeEventArgs e)
        {
            OnScrollChanged(e.ScrollX, e.ScrollY);
        }
        #endregion

        #region Constructors
        public ExtendedScrollView(Context context)
            : base(context)
        {
            Initialize();
        }

        public ExtendedScrollView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize();
        }

        public ExtendedScrollView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            Initialize();
        }

        public ExtendedScrollView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            Initialize();
        }

        public ExtendedScrollView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Initialize();
        }
        #endregion

        #region Private Methods
        private void Initialize()
        {
            ScrollChange += ExtendedScrollView_ScrollChange;
        }
        #endregion
    }
}