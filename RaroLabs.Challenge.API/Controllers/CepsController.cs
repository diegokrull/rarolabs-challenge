using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using RaroLabs.Challenge.Abstractions.Queries;
using RaroLabs.Challenge.Abstractions.TransferObjects;

namespace RaroLabs.Challenge.API.Controllers
{
    [ApiController]
    [Route("api/ceps")]
    public class CepsController : ControllerBase
    {
        private readonly ILogger<CepsController> logger;
        private readonly ICepQuery cepQuery;

        public CepsController(ILogger<CepsController> logger,
                              ICepQuery cepQuery)
        {
            this.logger = logger;
            this.cepQuery = cepQuery;
        }

        [HttpGet, Route("{cep}")]
        public async Task<ActionResult<CepDTO>> GetAsync([FromRoute] string cep)
        {
            var cepResult = await cepQuery.GetAsync(cep);

            if (cepResult == null)
                return NoContent();

            return cepResult;
        }
    }
}