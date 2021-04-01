using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using MvvmCross.DroidX.RecyclerView;
using System;

namespace MiCamConfig.App.Droid.Views
{
    public class ExtendedMvxRecyclerView : MvxRecyclerView
    {
        #region Properties
        /// <summary>
        /// Gets the current horizontal scroll position.
        /// </summary>
        public int HorizontalScrollPosition { get; private set; }

        /// <summary>
        /// Gets the current vertical scroll position.
        /// </summary>
        public int VerticalScrollPosition { get; private set; }
        #endregion

        #region Event Handlers
        public override void OnScrolled(int dx, int dy)
        {
            base.OnScrolled(dx, dy);

            HorizontalScrollPosition += dx;
            VerticalScrollPosition += dy;
        }
        #endregion

        #region Constructors
        public ExtendedMvxRecyclerView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize();
        }

        public ExtendedMvxRecyclerView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            Initialize();
        }

        public ExtendedMvxRecyclerView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            Initialize();
        }

        public ExtendedMvxRecyclerView(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter)
            : base(context, attrs, defStyle, adapter)
        {
            Initialize();
        }
        #endregion

        #region Private Methods
        private void Initialize()
        {
            OverScrollMode = OverScrollMode.Never;
        }
        #endregion
    }
}