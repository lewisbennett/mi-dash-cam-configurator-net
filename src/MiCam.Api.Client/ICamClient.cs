using MiCam.Api.Client.Operations;

namespace MiCam.Api.Client
{
    public interface ICamClient
    {
        IAdminOperations AdminOperations { get; }
    }
}
