using Android;
using Android.App;
using Android.Content.PM;
using Android.Support.V4.Content;
using System.Collections.Generic;

namespace MiCamConfig.App.Droid.Services
{
    public class PermissionsService : IPermissionsService
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the user has already been asked to grant permissions.
        /// </summary>
        public bool HasAskedForPermissions { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Asks the user for the required permissions.
        /// </summary>
        /// <param name="activity"></param>
        public void AskForPermissions(Activity activity)
        {
            var permissions = new List<string>();

            if (ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
                permissions.Add(Manifest.Permission.AccessCoarseLocation);

            if (permissions.Count > 0)
                activity.RequestPermissions(permissions.ToArray(), 100);

            HasAskedForPermissions = true;
        }
        #endregion
    }
}