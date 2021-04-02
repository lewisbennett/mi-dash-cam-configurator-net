using Android.Views;
using Android.Widget;
using Google.Android.Material.Button;

namespace MiCamConfig.App.Droid
{
    // This class is never used however, it contains extremely simple uses of certain view properties and event handlers.
    // The goal with the file is to trick the Xamarin linker so that it includes the parts of the app that MvvmCross needs
    // in order to provide us with binding functionality. This is because MvvmCross uses reflection and does not reference
    // things explicitly.

    public class LinkerPleaseInclude
    {
        #region Public Methods
        public void Include(View view)
        {
            view.Click += (s, e) => { };

            view.LongClick += (s, e) => { };

            view.Visibility += 1;
        }

        public void Include(TextView textView)
        {
            textView.AfterTextChanged += (s, e) => textView.Text = $"{textView.Text}";
        }

        public void Include(MaterialButton materialButton)
        {
            materialButton.Enabled = !materialButton.Enabled;
        }

        public void Include(CompoundButton compoundButton)
        {
            // This is responsible for text appearing as well.
            compoundButton.CheckedChange += (s, e) => { };
        }

        public void Include(NumberPicker picker)
        {
            picker.ValueChanged += (s, e) => picker.Value += 1;
        }

        public void Include(ToggleButton toggleButton)
        {
            toggleButton.TextChanged += (s, e) =>
            {
                toggleButton.Text = $"{toggleButton.Text}";
                toggleButton.TextOn = $"{toggleButton.TextOn}";
                toggleButton.TextOff = $"{toggleButton.TextOff}";
            };
        }

        public void Include(SeekBar seekBar)
        {
            // ProgressChanged accounts for the Progress property as well.
            seekBar.ProgressChanged += (s, e) =>
            {
                seekBar.Min += 1;
                seekBar.Max += 1;
            };
        }
        #endregion
    }
}