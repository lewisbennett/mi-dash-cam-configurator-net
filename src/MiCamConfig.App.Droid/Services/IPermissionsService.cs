using Android.App;

namespace MiCamConfig.App.Droid.Services
{
    public interface IPermissionsService
    {
        bool HasAskedForPermissions { get; set; }
        void AskForPermissions(Activity activity);
    }
}