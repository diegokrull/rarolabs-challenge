using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace RaroLabs.Challenge.Core.API
{
    public interface IClientAPI
    {
        Task<T> Get<T>(string url);
    }
}