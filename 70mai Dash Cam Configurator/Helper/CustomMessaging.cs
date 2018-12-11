using Android.App;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Views;

namespace MiDashCamConfigurator.Helper
{
    public class CustomMessaging
    {
        public static void ShowSnackbar(string message)
        {
            Snackbar snackbar = Snackbar.Make(Constants.ActiveCoordinatorLayout, message, Snackbar.LengthLong);
            View snackbarView = snackbar.View;
            snackbarView.SetBackgroundColor(new Color(ContextCompat.GetColor(Application.Context, Resource.Color.app_primary)));
            snackbar.Show();
        }
    }
}