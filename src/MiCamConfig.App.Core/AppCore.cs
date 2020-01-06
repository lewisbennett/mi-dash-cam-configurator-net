using MiCam.Api.Client;
using System;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core
{
    public class AppCore
    {
        #region Properties
        /// <summary>
        /// Gets the app's CamClient.
        /// </summary>
        public static CamClient CamClient { get; } = new CamClient();
        #endregion

        #region Public Methods
        /// <summary>
        /// Breaks down an exception to a user readable error message.
        /// </summary>
        public static void HandleException(Exception exception)
        {
        }

        /// <summary>
        /// Runs a task and handles any exceptions.
        /// </summary>
        public static async Task<bool> RunTaskAsync(Func<Task> task)
        {
            try
            {
                await task.Invoke().ConfigureAwait(false);

                return true;
            }
            catch (Exception e)
            {
                HandleException(e);
                return false;
            }
        }
        #endregion
    }
}
