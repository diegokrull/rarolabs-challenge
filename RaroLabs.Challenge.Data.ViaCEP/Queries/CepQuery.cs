using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RaroLabs.Challenge.Abstractions.Queries;
using RaroLabs.Challenge.Abstractions.TransferObjects;
using RaroLabs.Challenge.Abstractions.Settings;
using RaroLabs.Challenge.Core.API;
using RaroLabs.Challenge.Core.Settings;
using System.Net.Http;

namespace RaroLabs.Challenge.Data.ViaCEP.Queries
{
    public class CepQuery : ICepQuery
    {
        private ViaCepSettings viaCepSettings;
        private readonly IClientAPI clientAPI;

        public CepQuery(IAppSettings appSettings, IClientAPI clientAPI)
        {
            viaCepSettings = appSettings?.GetViaCepSettings();
            if (viaCepSettings == null || string.IsNullOrWhiteSpace(viaCepSettings.Url))
                throw new ArgumentException("Não foi encontrado o endereço da API Via Cep nas configurações do sistema.");

            this.clientAPI = clientAPI;
        }

        public async Task<CepDTO> GetAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return null;

            StringBuilder cepNumbers = new StringBuilder();
            foreach (Match cepNumericMatch in Regex.Matches(cep, @"\d+"))
                cepNumbers.Append(cepNumericMatch);
            
            var url = $@"{viaCepSettings.Url}/{cepNumbers}/json";

            try
            {
                return await clientAPI.Get<CepDTO>(url);
            }
            catch (HttpRequestException httpReqEx)
            {
                throw new ApplicationException("Ocorreu um erro ao buscar os dados postais na Via CEP.", httpReqEx);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
