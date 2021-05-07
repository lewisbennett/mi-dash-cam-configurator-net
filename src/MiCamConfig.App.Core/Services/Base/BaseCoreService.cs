using DialogMessaging;
using DialogMessaging.Interactions;
using MiCam.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core.Services.Base
{
    public abstract class BaseCoreService : ICoreService
    {
        #region Fields
        private long _savedInstanceCounter;
        private readonly Dictionary<long, IDictionary<string, object>> _savedInstances = new Dictionary<long, IDictionary<string, object>>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the app's <see cref="MiCam.Api.Client.CamClient" />.
        /// </summary>
        public CamClient CamClient { get; } = new CamClient();
        #endregion

        #region Public Methods
        /// <summary>
        /// Execute a task, with optional success and exception handlers.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        /// <param name="exceptionHandler">A function invoked to generate a messaging configuration if an exception is thrown.</param>
        public async Task ExecuteTaskAsync(Task task, Func<Exception, object> exceptionHandler = null)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                HandleException(e, exceptionHandler);
            }
        }

        /// <summary>
        /// Retrieves a saved instance state.
        /// </summary>
        /// <param name="instanceId">The instance ID of the saved state.</param>
        public bool TryRetrieveInstanceState(long instanceId, out IDictionary<string, object> state)
        {
            return _savedInstances.TryGetValue(instanceId, out state);
        }

        /// <summary>
        /// Saves an instance state.
        /// </summary>
        /// <param name="state">The state to be saved.</param>
        public long SaveInstanceState(IDictionary<string, object> state)
        {
            _savedInstanceCounter++;

            _savedInstances[_savedInstanceCounter] = state;

            return _savedInstanceCounter;
        }
        #endregion

        #region Private Methods
        private void HandleException(Exception exception, Func<Exception, object> exceptionHandler)
        {
            if (exceptionHandler == null)
                throw exception;

            var messagingConfig = exceptionHandler.Invoke(exception);

            var messagingService = MessagingService.Instance;

            switch (messagingConfig)
            {
                case AlertConfig alertConfig:
                    messagingService.Alert(alertConfig);
                    return;

                case SnackbarConfig snackbarConfig:
                    messagingService.Snackbar(snackbarConfig);
                    return;

                default:
                    throw new NotSupportedException($"{messagingConfig.GetType()} is not a valid messaging type.");
            }
        }
        #endregion
    }
}
