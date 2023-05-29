using B3.CDB.API.Model;
using B3.CDB.API.Service;
using B3.CDB.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace B3.CDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [OpenApiTag("CdbCalculator")]
    public class CdbCalculatorController : ControllerBase
    {
        private readonly ICdbCalculatorService _cdbCalculatorService;

        public CdbCalculatorController(ICdbCalculatorService cdbCalculatorService)
        {
            _cdbCalculatorService = cdbCalculatorService;
        }

        /// <summary>
        /// Calculate CDB
        /// </summary>
        /// <param name="CdbCalculatorRequest"></param>
        /// <returns>A return amount gross and net</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /
        ///     {
        ///        "monthlyTerm": 2,
        ///        "initialAmounting": "1000.00",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns gross and net value</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">Server Error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CdbCalculatorResponse> Calculate(CdbCalculatorRequest request)
        {
            var result = _cdbCalculatorService.CdbCalculate(request);

            return Ok(result);
        }

    }
}