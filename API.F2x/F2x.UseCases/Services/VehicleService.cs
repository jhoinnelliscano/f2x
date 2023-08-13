using F2x.EntityDomain.Domain;
using F2x.RepositoryInterface.Interfaces;
using F2x.UseCases.Interfaces;

namespace F2x.UseCases.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;

        }
        public async Task<IEnumerable<Vehicle>> GetVehiclesByFiltersAsyn(string? category, string? station, string? direction, DateTime? startDate, DateTime? endDate, int hour)
        {
            return await _vehicleRepository.GetVehiclesByFiltersAsyn(category, station, direction, startDate, endDate, hour);
        }
    }
}
