
namespace F2x.UseCases.Interfaces
{
    public interface IStationService
    {
        Task<IEnumerable<string>> GetAllStationsAsync();
    }
}
