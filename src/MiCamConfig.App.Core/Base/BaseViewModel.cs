using MiCamConfig.App.Core.Services;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.Base
{
    public class BaseViewModel : MvxViewModel
    {
        #region Fields
        private IMvxCommand _backButtonClickCommand;
        private string _title;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the command triggered when the back button is clicked.
        /// </summary>
        public IMvxCommand BackButtonClickCommand
        {
            get
            {
                _backButtonClickCommand = _backButtonClickCommand ?? new MvxAsyncCommand(Back_ClickAsync);

                return _backButtonClickCommand;
            }
        }

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        public IMvxNavigationService NavigationService { get; } = Mvx.IoCProvider.Resolve<IMvxNavigationService>();

        /// <summary>
        /// Gets or sets the title for this ViewModel.
        /// </summary>
        public virtual string Title
        {
            get => _title;

            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        /// <summary>
        /// Gets the WiFi service.
        /// </summary>
        public IWifiService WifiService { get; } = Mvx.IoCProvider.Resolve<IWifiService>();
        #endregion

        #region Event Handlers
        private async Task Back_ClickAsync()
        {
            await NavigationService.Close(this).ConfigureAwait(false);
        }
        #endregion
    }
}
