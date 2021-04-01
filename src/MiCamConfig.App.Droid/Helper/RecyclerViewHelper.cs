using DialogMessaging;
using System;

namespace MiCamConfig.App.Droid.Helper
{
    public static class RecyclerViewHelper
    {
        #region Public Methods
        /// <summary>
        /// Calculates how many items should be shown horizontally based on the item's nominal width.
        /// </summary>
        /// <param name="nominalWidth">The nominal width of the item (in DP).</param>
        public static int CalculateHorizontalItemCount(float nominalWidth)
        {
            var context = MessagingService.ActivityLifecycleCallbacks.CurrentActivity;

            // Calculate the width of the screen in DP.
            var widthDp = context.Resources.DisplayMetrics.WidthPixels / context.Resources.DisplayMetrics.Density;

            // Round the DP width to the nearest hundred.
            var roundedWidthDp = Math.Round(widthDp / 100, 0) * 100;

            // The horizontal item count is the rounded down result of dividing the rounded DP width by the nominal width.
            return (int)Math.Max(1, Math.Floor(roundedWidthDp / nominalWidth));
        }
        #endregion
    }
}