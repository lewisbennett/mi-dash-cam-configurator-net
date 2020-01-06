using MiCam.Api.Client.Entities;
using System.Threading.Tasks;

namespace MiCam.Api.Client.Operations
{
    public interface IAdminOperations
    {
        Task<ResponseEntity> ApkAuthorizeAsync();
    }
}
