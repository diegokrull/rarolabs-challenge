using System.Threading.Tasks;
using RaroLabs.Challenge.Abstractions.TransferObjects;

namespace RaroLabs.Challenge.Abstractions.Queries
{
    public interface ICepQuery
    {
        Task<CepDTO> GetAsync(string cep);
    }
}
