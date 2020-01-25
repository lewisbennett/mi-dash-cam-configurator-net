using DialogMessaging;
using DialogMessaging.Interactions;
using System.Threading;
using System.Threading.Tasks;

namespace MiCamConfig.App.Core
{
    public static class Extensions
    {
        #region Public Methods
        /// <summary>
        /// Displays a loading wheel to the user asynchronously.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="task">The task to execute.</param>
        public static TTask ShowLoadingAsync<TTask>(this IMessagingService messagingService, string message, TTask task, CancellationToken cancellationToken = default)
            where TTask : Task
        {
            return messagingService.ShowLoadingAsync(new LoadingAsyncConfig { Message = message }, task, cancellationToken);
        }
        #endregion
    }
}
