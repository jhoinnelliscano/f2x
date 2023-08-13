
using F2x.EntityDomain.Domain;

namespace F2x.RepositoryInterface.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehiclesByFiltersAsyn(string? category, string? station, string? direction, DateTime? startDate, DateTime? endDate, int hour);
        Task<IEnumerable<Vehicle>> GetVehiclesByFiltersAsyn(string? category, string? station, string? direction, int month, int year);
        Task<IEnumerable<string>> GetVehicleCategoriesAsync();
        Task<IEnumerable<string>> GetVehicleStationsAsync();
        Task<IEnumerable<string>> GetVehicleDirectionsAsync();
    }
}
