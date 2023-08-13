
using F2x.EntityDomain.Domain;
using F2x.EntityDomain.Domain.TabulatedReport;

namespace F2x.UseCases.Interfaces
{
    public interface IReportTabulatedValueService
    {
        Task<TabulatedValueReport> GetReportAsync(string? category, string? station, string? direction, int month, int year);
    }
}
