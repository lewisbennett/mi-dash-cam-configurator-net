using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using MvvmCross.DroidX.RecyclerView;
using System;
using System.Collections.Generic;

namespace MiCamConfig.App.Droid.Views
{
    public class ElevationMvxRecyclerView : MvxRecyclerView
    {
        #region Fields
        private readonly List<View> _elevationViews = new List<View>();
        #endregion

        #region Event Handlers
        public override void OnScrolled(int dx, int dy)
        {
            base.OnScrolled(dx, dy);

            if (_elevationViews.Count > 0)
            {
                var shouldSelect = ShouldSelect();

                foreach (var view in _elevationViews)
                    view.Selected = shouldSelect;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Registers a view to be elevated when this ElevationMvxRecyclerView is scrolled.
        /// </summary>
        /// <param name="view">The view to be registered.</param>
        public void RegisterElevationView(View view)
        {
            if (!_elevationViews.Contains(view))
                _elevationViews.Add(view);

            view.Selected = ShouldSelect();
        }

        /// <summary>
        /// Unregisters a view from being elevated when this ElevationMvxRecyclerView is scrolled.
        /// </summary>
        /// <param name="view">The view to be unregistered.</param>
        public void UnregisterElevationView(View view)
        {
            view.Selected = false;

            _elevationViews.Remove(view);
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

        #region Private Methods
        private bool ShouldSelect()
        {
            return CanScrollVertically(-1);
        }
        #endregion
    }
}