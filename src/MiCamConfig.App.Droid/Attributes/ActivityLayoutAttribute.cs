using System;

namespace MiCamConfig.App.Droid.Attributes
{
    public class ActivityLayoutAttribute : Attribute
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether or not the back button should be enabled.
        /// </summary>
        public bool EnableBackButton { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the layout file to display.
        /// </summary>
        public int LayoutResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the menu to be displayed.
        /// </summary>
        /// <remarks>The activity must have a valid SupportActionBar to display the menu.</remarks>
        public int MenuResourceId { get; set; }
        #endregion
    }
}