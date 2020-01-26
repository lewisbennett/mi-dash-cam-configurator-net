using Android.Views;
using MvvmCross.Converters;
using System;
using System.Globalization;

namespace MiCamConfig.App.Droid.ValueConverters
{
    public class VisibilityValueConverter : MvxValueConverter<bool, ViewStates>
    {
        #region Public Methods
        protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? ViewStates.Visible : ViewStates.Gone;
        }

        protected override bool ConvertBack(ViewStates value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == ViewStates.Visible;
        }
        #endregion
    }
}