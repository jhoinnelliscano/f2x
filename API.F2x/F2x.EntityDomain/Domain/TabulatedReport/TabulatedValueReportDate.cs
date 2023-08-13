
namespace F2x.EntityDomain.Domain.TabulatedReport
{
    public class TabulatedValueReportDate
    {
        public DateTime Date { get; set; }
        public IEnumerable<TabulatedValueReportDateDetail> Detail { get; set; }
    }
}
