
using F2x.EntityDomain.Domain;

namespace F2x.UnitTest
{
    public static class UnitTestHelper
    {
        public static IEnumerable<Vehicle> GetVehiclesData()
        {
            return new List<Vehicle>() 
            { 
                new Vehicle()
                { 
                     Category = "I",
                     Date = DateTime.Now,
                     Direction = "BOG-CHI",
                     Quantity = 100,
                     TabulatedValue = 3376100,
                     Hour = 1,
                     Station = "ANDES"
                },
                new Vehicle()
                {
                     Category = "IV",
                     Date = DateTime.Now,
                     Direction = "BOG-CHI",
                     Quantity = 100,
                     TabulatedValue = 3376100,
                     Hour = 0,
                     Station = "UNISABANA"
                },
                new Vehicle()
                {
                     Category = "I",
                     Date = DateTime.Now,
                     Direction = "CHI-BOG",
                     Quantity = 100,
                     TabulatedValue = 3376100,
                     Hour = 2,
                     Station = "ANDES"
                },
                new Vehicle()
                {
                     Category = "III",
                     Date = DateTime.Now,
                     Direction = "BOG-CHI",
                     Quantity = 100,
                     TabulatedValue = 3376100,
                     Hour = 1,
                     Station = "ANDES"
                },
                new Vehicle()
                {
                     Category = "II",
                     Date = DateTime.Now,
                     Direction = "CHI-BOG",
                     Quantity = 100,
                     TabulatedValue = 3376100,
                     Hour = 0,
                     Station = "FUSCA"
                }
            };
        }

        public static IEnumerable<string> GetCategoriesData() 
        {
            return new List<string>() { "I", "II", "III", "IV", "V" };
        }

        public static IEnumerable<string> GetDirectionsData()
        {
            return new List<string>() { "BOG-CHI", "CHI-BOG" };
        }

        public static IEnumerable<string> GetStationsData()
        {
            return new List<string>() { "ANDES", "UNISABANA", "FUSCA" };
        }
    }
}
