using MiCam.Api.Client.Operations;

namespace MiCam.Api.Client
{
    public class CamClient : BaseCamClient, ICamClient
    {
        #region Properties
        /// <summary>
        /// Gets the admin operations.
        /// </summary>
        public IAdminOperations AdminOperations { get; private set; }
        #endregion

        #region Constructors
        public CamClient()
        {
            AdminOperations = new AdminOperations(this);
        }
        #endregion
    }
}
