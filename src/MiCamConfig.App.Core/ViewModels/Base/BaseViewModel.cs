using MiCam.Api.Client;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.ViewModels.Base
{
    public partial class BaseViewModel : MvxViewModel
    {
        #region Properties
        /// <summary>
        /// Gets the app's CamClient.
        /// </summary>
        public static CamClient CamClient => AppCore.CamClient;

        /// <summary>
        /// Runs a task and handles any exceptions.
        /// </summary>
        public Task<bool> RunTaskAsync(Func<Task> task)
        {
            return AppCore.RunTaskAsync(task);
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
