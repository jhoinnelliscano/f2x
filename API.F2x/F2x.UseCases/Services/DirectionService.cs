
using F2x.RepositoryInterface.Interfaces;
using F2x.UseCases.Interfaces;

namespace F2x.UseCases.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DirectionService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<string>> GetAllDirectionsAsync()
        { 
            return await _vehicleRepository.GetVehicleDirectionsAsync();
        }
    }
}
