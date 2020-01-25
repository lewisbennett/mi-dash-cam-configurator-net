using DialogMessaging;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
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
        /// Gets the messaging service.
        /// </summary>
        public IMessagingService MessagingService => DialogMessaging.MessagingService.Instance;

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        public IMvxNavigationService NavigationService { get; } = Mvx.IoCProvider.Resolve<IMvxNavigationService>();

        /// <summary>
        /// Runs a task and handles any exceptions.
        /// </summary>
        public Task<bool> RunTaskAsync(Func<Task> task)
        {
            return AppCore.RunTaskAsync(task);
        }

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
        #endregion

        #region Event Handlers
        private async Task Back_ClickAsync()
        {
            await NavigationService.Close(this).ConfigureAwait(false);
        }
        #endregion
    }
}
