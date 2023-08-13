using F2x.EntityDomain.Domain;
using F2x.EntityDomain.Objects;
using F2x.UseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace F2x.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ICategoryService _categoryService;
        private readonly IDirectionService _directionService;
        private readonly IStationService _stationService;

        public VehicleController(IVehicleService vehicleService, ICategoryService categoryService, IDirectionService directionService, IStationService stationService)
        {
            _vehicleService = vehicleService;
            _categoryService = categoryService;
            _directionService = directionService;
            _stationService = stationService;
        }

        /// <summary>
        /// Servicio para obtener datos en bruto
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesData(string? category, string? station, string? direction, DateTime startDate, DateTime endDate, int hour)
        {
            var result = await _vehicleService.GetVehiclesByFiltersAsyn(category, station, direction, startDate, endDate, hour);
            return Ok(result);
        }

        /// <summary>
        /// Servicio para obtener lista de categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("categories")]
        public async Task<ActionResult<IEnumerable<string>>> GetVehiclesCategories()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }


        /// <summary>
        /// Servicio para obtener la lista de sentidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("directions")]
        public async Task<ActionResult<IEnumerable<string>>> GetVehiclesDirections()
        {
            var result = await _directionService.GetAllDirectionsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Servicio para obtener la lista de estaciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("stations")]
        public async Task<ActionResult<IEnumerable<string>>> GetVehiclesStations()
        {
            var result = await _stationService.GetAllStationsAsync();
            return Ok(result);
        }

    }
}
