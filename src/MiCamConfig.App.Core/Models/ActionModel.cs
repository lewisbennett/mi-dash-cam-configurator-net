﻿using MiCamConfig.App.Core.Base;

namespace MiCamConfig.App.Core.Models
{
    public class ActionModel : BaseModel
    {
        #region Fields
        private string _title = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the optional data payload.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get => _title;

            set
            {
                value ??= string.Empty;

                if (_title.Equals(value))
                    return;

                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        #endregion
    }
}
