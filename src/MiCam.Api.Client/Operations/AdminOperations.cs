using MiCam.Api.Client.Entities;
using System.Threading.Tasks;

namespace MiCam.Api.Client.Operations
{
    public class AdminOperations : IAdminOperations
    {
        #region Fields
        private readonly IBaseApiRequestor _client;
        #endregion

        #region Public Methods
        /// <summary>
        /// Sends the ApkAuthorize request.
        /// </summary>
        public Task<ResponseEntity> ApkAuthorizeAsync()
        {
            return _client.GetAsync("ApkAuthorize");
        }
        #endregion

        #region Constructors
        public AdminOperations(IBaseApiRequestor client)
        {
            _client = client;
        }
        #endregion
    }
}
