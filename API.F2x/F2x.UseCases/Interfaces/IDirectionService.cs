
namespace F2x.UseCases.Interfaces
{
    public interface IDirectionService
    {
        Task<IEnumerable<string>> GetAllDirectionsAsync();
    }
}
