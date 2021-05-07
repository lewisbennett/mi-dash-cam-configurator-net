using MiCam.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.Services
{
    public interface ICoreService
    {
        #region Properties
        /// <summary>
        /// Gets the app's <see cref="MiCam.Api.Client.CamClient" />.
        /// </summary>
        CamClient CamClient { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Execute a task, with optional success and exception handlers.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        /// <param name="exceptionHandler">A function invoked to generate a messaging configuration if an exception is thrown.</param>
        Task ExecuteTaskAsync(Task task, Func<Exception, object> exceptionHandler = null);

        /// <summary>
        /// Retrieves a saved instance state.
        /// </summary>
        /// <param name="instanceId">The instance ID of the saved state.</param>
        bool TryRetrieveInstanceState(long instanceId, out IDictionary<string, object> state);

        /// <summary>
        /// Saves an instance state.
        /// </summary>
        /// <param name="state">The state to be saved.</param>
        long SaveInstanceState(IDictionary<string, object> state);
        #endregion
    }
}
