using F2x.EntityDomain.Domain;
using F2x.Persistence.Context;

namespace F2x.Persistence.Mappers
{
    public static class ObjectMapper
    {
        public static Vehicle MappToVehicle(Recaudo enity)
        {
            if (enity == null) return null;

            var domain = new Vehicle()
            {
                Category = enity.Categoria,
                Date = enity.Fecha,
                Direction = enity.Sentido,
                Hour = enity.Hora,
                Quantity = enity.Cantidad,
                TabulatedValue = enity.ValorTabulado,
                Station = enity.Estacion,
            };
            return domain;
        }        
    }
}
