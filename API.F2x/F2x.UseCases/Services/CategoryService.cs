
using F2x.RepositoryInterface.Interfaces;
using F2x.UseCases.Interfaces;

namespace F2x.UseCases.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public CategoryService(IVehicleRepository vehicleRepository) 
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<string>> GetAllCategoriesAsync()
        {
            return await _vehicleRepository.GetVehicleCategoriesAsync();
        }
    }
}
