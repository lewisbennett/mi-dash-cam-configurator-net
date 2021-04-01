using MiCam.Api.Client;
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
        /// Gets the app's CamClient.
        /// </summary>
        public static CamClient CamClient => AppCore.CamClient;

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
    }

    public class BaseViewModel<TNavigationParams> : BaseViewModel, IMvxViewModel<TNavigationParams>
        where TNavigationParams : class
    {
        #region Lifecycle
        public virtual void Prepare(TNavigationParams parameter)
        {
        }
        #endregion
    }
}
