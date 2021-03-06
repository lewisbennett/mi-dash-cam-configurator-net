﻿using MiCam.Api.Client.Entities;
using System.Threading.Tasks;

namespace MiCam.Api.Client.Operations
{
    public interface ISoundOperations
    {
        Task<ResponseEntity> GetSoundIndicatorAsync();
        Task<ResponseEntity> SetSoundIndicatorAsync(string value);
    }
}
