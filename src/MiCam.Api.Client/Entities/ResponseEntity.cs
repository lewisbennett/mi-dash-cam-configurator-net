using System;

namespace MiCam.Api.Client.Entities
{
    public class ResponseEntity
    {
        #region Properties
        /// <summary>
        /// Gets the name of the property that the value belongs to.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the raw response.
        /// </summary>
        public string RawResponse { get; }

        /// <summary>
        /// Gets whether the request was successful.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public object Value { get; }
        #endregion

        #region Constructors
        public ResponseEntity(string response)
        {
            RawResponse = response.Trim();

            var breakdown = RawResponse.Split('\n');

            PropertyName = breakdown[2].Replace("=", string.Empty);
            Success = breakdown[1].Equals("OK", StringComparison.CurrentCultureIgnoreCase);
            Value = breakdown[0];
        }
        #endregion
    }
}
