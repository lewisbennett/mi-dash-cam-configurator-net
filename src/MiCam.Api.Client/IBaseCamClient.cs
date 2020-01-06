using System;
using System.Net.Http;

namespace MiCam.Api.Client
{
    public interface IBaseCamClient
    {
        HttpClient Client { get; }
        int RetryCount { get; set; }
        TimeSpan RetryDelay { get; set; }
    }
}
