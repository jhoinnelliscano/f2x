using F2x.EntityDomain.Domain;

namespace F2x.UseCases.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetVehiclesByFiltersAsyn(string? category, string? station, string? direction, DateTime? startDate, DateTime? endDate, int hour);
    }
}
