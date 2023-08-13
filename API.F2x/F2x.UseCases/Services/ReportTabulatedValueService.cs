
using F2x.EntityDomain.Domain;
using F2x.EntityDomain.Domain.TabulatedReport;
using F2x.Persistence.Repositories;
using F2x.RepositoryInterface.Interfaces;
using F2x.UseCases.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace F2x.UseCases.Services
{
    public class ReportTabulatedValueService : IReportTabulatedValueService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public ReportTabulatedValueService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<TabulatedValueReport> GetReportAsync(string? category, string? station, string? direction, int month, int year)
        {
            var vehicles = await _vehicleRepository.GetVehiclesByFiltersAsyn(category, station, direction, month, year);

            var stationsDetail =
                from v in vehicles
                group v by new
                {
                    v.Station,
                    v.Date
                } into gv
                select new TabulatedValueReportStationDetail()
                {
                    StationName = gv.Key.Station,
                    Date = gv.Key.Date,
                    TotalQuantity = gv.Sum(x => x.Quantity),
                    TotalValue = gv.Sum(x => x.TabulatedValue),
                };

            var stations =
                from d in stationsDetail
                group d by new
                {
                    d.StationName
                } into gd
                select new TabulatedValueReportStation()
                {
                    StationName = gd.Key.StationName,
                    TotalQuantity = gd.Sum(x => x.TotalQuantity),
                    TotalValue = gd.Sum(x => x.TotalValue),
                };

            var dates = stationsDetail.Select(x=>x.Date).Distinct().ToList();
            var dateList = new List<TabulatedValueReportDate>();

            foreach (var dateItem in dates) 
            {
                var newDateItem = new TabulatedValueReportDate()
                {
                    Date = dateItem,  
                };

                var detailList = new List<TabulatedValueReportDateDetail>();

                foreach (var stationItem in stations) 
                {
                    var newStationDetail = new TabulatedValueReportDateDetail()
                    {
                        Station = stationItem.StationName,
                    };

                    var stationDetail = stationsDetail.FirstOrDefault(x => x.Date == dateItem && x.StationName.Equals(stationItem.StationName));

                    newStationDetail.TotalQuantity = stationDetail != null ? stationDetail.TotalQuantity : 0;
                    newStationDetail.TotalValue = stationDetail != null ? stationDetail.TotalValue : 0;

                    detailList.Add(newStationDetail);
                }
                newDateItem.Detail = detailList;
                dateList.Add(newDateItem);
            }

            var report = new TabulatedValueReport()
            {
                Stations = stations,
                Dates = dateList,
                TotalQuantity = stations.Sum(x => x.TotalQuantity),
                TotalValue = stations.Sum(x => x.TotalValue),
            };

            return report;
        }
    }
}
