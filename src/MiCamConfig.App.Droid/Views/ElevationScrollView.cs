using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using System;
using System.Collections.Generic;

namespace MiCamConfig.App.Droid.Views
{
    public class ElevationScrollView : ExtendedScrollView
    {
        #region Properties
        /// <summary>
        /// Gets the collection of views that should have different elevation values when this view scrolls.
        /// </summary>
        public IList<View> ElevationViews { get; } = new List<View>();
        #endregion

        #region Event Handlers
        public override void OnScrollChanged(int dx, int dy)
        {
            base.OnScrollChanged(dx, dy);

            if (ElevationViews.Count < 1)
                return;

            var selected = dy != 0;

            foreach (var view in ElevationViews)
                view.Selected = selected;
        }
        #endregion

        #region Constructors
        public ElevationScrollView(Context context)
            : base(context)
        {
        }

        public ElevationScrollView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public ElevationScrollView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public ElevationScrollView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }

        public ElevationScrollView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }
        #endregion
    }
}