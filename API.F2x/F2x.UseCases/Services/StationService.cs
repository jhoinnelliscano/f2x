
using F2x.RepositoryInterface.Interfaces;
using F2x.UseCases.Interfaces;

namespace F2x.UseCases.Services
{
    public class StationService : IStationService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public StationService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<string>> GetAllStationsAsync()
        {
            return await _vehicleRepository.GetVehicleStationsAsync();
        }
    }
}
