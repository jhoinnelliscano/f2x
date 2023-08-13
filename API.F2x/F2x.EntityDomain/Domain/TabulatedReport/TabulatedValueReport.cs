namespace F2x.EntityDomain.Domain.TabulatedReport
{
    public class TabulatedValueReport
    {
        public IEnumerable<TabulatedValueReportStation> Stations { get; set; }
        public IEnumerable<TabulatedValueReportDate> Dates { get; set; }
        public decimal TotalValue { get; set; }
        public long TotalQuantity { get; set; }
    }
}
