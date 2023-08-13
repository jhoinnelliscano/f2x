
namespace F2x.UseCases.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>> GetAllCategoriesAsync();
    }
}
