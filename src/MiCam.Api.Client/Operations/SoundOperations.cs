using MiCam.Api.Client.Entities;
using MiCam.Api.Client.Schema;
using System.Threading.Tasks;

namespace MiCam.Api.Client.Operations
{
    public class SoundOperations : ISoundOperations
    {
        #region Fields
        private readonly IBaseApiRequestor _client;
        #endregion

        #region Public Methods
        /// <summary>
        /// Sends the ApkAuthorize request.
        /// </summary>
        public Task<ResponseEntity> SoundIndicatorAsync(string value)
        {
            return _client.SetAsync(Code.SoundIndicator, value);
        }
        #endregion

        #region Constructors
        public SoundOperations(IBaseApiRequestor client)
        {
            _client = client;
        }
        #endregion
    }
}
