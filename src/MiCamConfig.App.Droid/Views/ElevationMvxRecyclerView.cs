using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using System;
using System.Collections.Generic;

namespace MiCamConfig.App.Droid.Views
{
    public class ElevationMvxRecyclerView : ExtendedMvxRecyclerView
    {
        #region Properties
        /// <summary>
        /// Gets the collection of views that should have different elevation values when this view scrolls.
        /// </summary>
        public IList<View> ElevationViews { get; } = new List<View>();
        #endregion

        #region Event Handlers
        public override void OnScrolled(int dx, int dy)
        {
            base.OnScrolled(dx, dy);

            if (ElevationViews.Count < 1)
                return;

            var selected = VerticalScrollPosition != 0;

            foreach (var view in ElevationViews)
                view.Selected = selected;
        }
        #endregion

        #region Constructors
        public ElevationMvxRecyclerView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public ElevationMvxRecyclerView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public ElevationMvxRecyclerView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        public ElevationMvxRecyclerView(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter)
            : base(context, attrs, defStyle, adapter)
        {
        }
        #endregion
    }
}