using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace MiCamConfig.App.Droid.DialogFragments
{
    public class LoadingDialogFragment : DialogFragment
    {
        #region Fields
        private TextView _tvMessage;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; private set; }
        #endregion

        #region Lifecycle
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (savedInstanceState != null)
                Message = savedInstanceState.GetString(ConfigBundleKey, string.Empty);

            var view = inflater.Inflate(Resource.Layout.dialog_loading, null, false);

            _tvMessage = view.FindViewById<TextView>(Resource.Id.loading_text);

            Cancelable = false;

            if (string.IsNullOrWhiteSpace(Message))
                _tvMessage.Visibility = ViewStates.Gone;

            else
                _tvMessage.Text = Message;

            return view;
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            outState.PutString(ConfigBundleKey, Message);
        }
        #endregion

        #region Constructors
        public LoadingDialogFragment()
        {
            SetStyle(StyleNormal, Resource.Style.AppTheme_Dialog_Base);
        }

        public LoadingDialogFragment(string message)
            : this()
        {
            Message = message;
        }
        #endregion

        #region Static Properties
        public const string ConfigBundleKey = "config";
        #endregion
    }
}