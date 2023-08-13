using F2x.EntityDomain.Domain;
using F2x.Persistence.Context;
using F2x.Persistence.Helpers;
using F2x.Persistence.Mappers;
using F2x.RepositoryInterface.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace F2x.Persistence.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DatabaseContext _dbContext;

        public VehicleRepository(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByFiltersAsyn(string? category, string? station, string? direction, DateTime? startDate, DateTime? endDate, int hour)
        {
            var filter = RecaudoEntityHelper.FiltersExpression(category, station, direction, startDate, endDate, hour);

            IQueryable<Recaudo> query = _dbContext.Recaudos;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            var result = await query.ToListAsync();

            var vehicles = _dbContext.Recaudos.Where(x => x.Fecha >= startDate && x.Fecha <= endDate).ToList();

            var vehiclesEntity = result.Select(x => ObjectMapper.MappToVehicle(x)).ToList();
            return vehiclesEntity;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByFiltersAsyn(string? category, string? station, string? direction, int month, int year)
        {
            var filter = RecaudoEntityHelper.FiltersExpression(category, station, direction, month, year);

            IQueryable<Recaudo> query = _dbContext.Recaudos;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            var result = await query.ToListAsync();

            var vehiclesEntity = result.Select(x => ObjectMapper.MappToVehicle(x)).ToList();
            return vehiclesEntity;
        }

        public async Task<IEnumerable<string>> GetVehicleCategoriesAsync() 
        {
           return await _dbContext.Recaudos
                .Select(x => x.Categoria)
                .Distinct()
                .OrderBy(x=>x)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetVehicleStationsAsync()
        {
            return await _dbContext.Recaudos
                 .Select(x => x.Estacion)
                 .Distinct()
                 .OrderBy(x => x)
                 .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetVehicleDirectionsAsync()
        {
            return await _dbContext.Recaudos
                 .Select(x => x.Sentido)
                 .Distinct()
                 .OrderBy(x => x)
                 .ToListAsync();
        }
    }
}
