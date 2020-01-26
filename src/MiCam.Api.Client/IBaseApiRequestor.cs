using MiCam.Api.Client.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiCam.Api.Client
{
    public interface IBaseApiRequestor
    {
        Task<ResponseEntity> GetAsync(string propertyName);
        Task<HttpResponseMessage> RawRequestAsync(string action, string propertyName, object value = null);
        Task<ResponseEntity> RequestAsync(string action, string propertyName, object value = null);
        Task<ResponseEntity> SetAsync(string propertyName, string value);
    }
}
