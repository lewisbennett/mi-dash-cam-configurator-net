namespace MiCam.Api.Client.Entities
{
    public class ResponseEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the property that the value belongs to.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the raw response.
        /// </summary>
        public string RawResponse { get; set; }

        /// <summary>
        /// Gets or sets whether the request was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }
        #endregion
    }
}
