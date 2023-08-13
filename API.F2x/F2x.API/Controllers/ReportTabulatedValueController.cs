using F2x.EntityDomain.Domain;
using F2x.EntityDomain.Domain.TabulatedReport;
using F2x.EntityDomain.Objects;
using F2x.UseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace F2x.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTabulatedValueController : ControllerBase
    {
        private readonly IReportTabulatedValueService _reportTabulatedValueService;

        public ReportTabulatedValueController(IReportTabulatedValueService reportTabulatedValueService)
        {
            _reportTabulatedValueService = reportTabulatedValueService;
        }

        /// <summary>
        /// Servicio para obtener reporte de valor tabulado mensual
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<TabulatedValueReport>> GetVehiclesData(string? category, string? station, string? direction, int month, int year)
        {
            var result = await _reportTabulatedValueService.GetReportAsync(category, station, direction, month, year);
            return Ok(result);
        }
    }
}
