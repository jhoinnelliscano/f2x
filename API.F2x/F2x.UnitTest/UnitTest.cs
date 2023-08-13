using F2x.EntityDomain.Domain;
using F2x.RepositoryInterface.Interfaces;
using F2x.UnitTest;
using F2x.UseCases.Interfaces;
using F2x.UseCases.Services;
using Moq;


namespace F2x.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public async Task Get_Vehicles_Data()
        {
            var data = UnitTestHelper.GetVehiclesData();
            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository.Setup(x => x.GetVehiclesByFiltersAsyn("", "", "", DateTime.Now, DateTime.Now, 1))
                      .ReturnsAsync(data);

            IVehicleService service = new VehicleService(vehicleRepository.Object);
            var result = await service.GetVehiclesByFiltersAsyn("", "", "", DateTime.Now, DateTime.Now, 1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_Report_Data()
        {
            var data = UnitTestHelper.GetVehiclesData();
            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository.Setup(x => x.GetVehiclesByFiltersAsyn("", "", "", 1, 2))
                      .ReturnsAsync(data);

            IReportTabulatedValueService service = new ReportTabulatedValueService(vehicleRepository.Object);
            var result = await service.GetReportAsync("", "", "", 1, 2);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_Vehicles_Categories()
        {
            var categories = UnitTestHelper.GetCategoriesData();
            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository.Setup(x => x.GetVehicleCategoriesAsync())
                      .ReturnsAsync(categories);

            ICategoryService service = new CategoryService(vehicleRepository.Object);
            var result = await service.GetAllCategoriesAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_Vehicles_Directions()
        {
            var directions = UnitTestHelper.GetCategoriesData();
            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository.Setup(x => x.GetVehicleCategoriesAsync())
                      .ReturnsAsync(directions);

            IDirectionService service = new DirectionService(vehicleRepository.Object);
            var result = await service.GetAllDirectionsAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_Vehicles_Stations()
        {
            var stations = UnitTestHelper.GetCategoriesData();
            var vehicleRepository = new Mock<IVehicleRepository>();

            vehicleRepository.Setup(x => x.GetVehicleCategoriesAsync())
                      .ReturnsAsync(stations);

            IStationService service = new StationService(vehicleRepository.Object);
            var result = await service.GetAllStationsAsync();

            Assert.NotNull(result);
        }
    }
}