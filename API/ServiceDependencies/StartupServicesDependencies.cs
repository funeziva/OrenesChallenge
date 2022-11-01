using API.Utils;
using Application.Customers.Create;
using Application.Customers.Delete;
using Application.Customers.Find;
using Application.Customers.Search;
using Application.Customers.Update;
using Application.Drivers.Create;
using Application.Drivers.Delete;
using Application.Drivers.Find;
using Application.Drivers.Search;
using Application.Drivers.Update;
using Application.Orders.Create;
using Application.Orders.Delete;
using Application.Orders.Find;
using Application.Orders.Search;
using Application.Orders.Update;
using Application.UbicationHistories.Search;
using Application.Vehicles.Create;
using Application.Vehicles.Delete;
using Application.Vehicles.Find;
using Application.Vehicles.Search;
using Application.Vehicles.Update;
using Domain.Customers;
using Domain.Drivers;
using Domain.Orders;
using Domain.UbicationHistories;
using Domain.Vehicles;
using Infrastructure.Customers;
using Infrastructure.Drivers;
using Infrastructure.Orders;
using Infrastructure.UbicationHistorys;
using Infrastructure.Vehicles;

namespace API.ServiceDependencies
{
    public static class StartupServicesDependencies
    {
        public static IServiceCollection AddServicesApplicationInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<HelperJWT>();

            services.AddTransient<VehicleSearcher>();
            services.AddTransient<VehicleUpdater>();
            services.AddTransient<VehicleDeleter>();
            services.AddTransient<VehicleFinder>();
            services.AddTransient<VehicleCreator>();
            services.AddTransient<VehicleUpdaterUbication>();

            services.AddTransient<DriverSearcher>();
            services.AddTransient<DriverUpdater>();
            services.AddTransient<DriverDeleter>();
            services.AddTransient<DriverFinder>();
            services.AddTransient<DriverCreator>();

            services.AddTransient<CustomerSearcher>();
            services.AddTransient<CustomerUpdater>();
            services.AddTransient<CustomerDeleter>();
            services.AddTransient<CustomerFinder>();
            services.AddTransient<CustomerCreator>();

            services.AddTransient<OrderSearcher>();
            services.AddTransient<OrderUpdater>();
            services.AddTransient<OrderDeleter>();
            services.AddTransient<OrderFinder>();
            services.AddTransient<OrderCreator>();

            services.AddTransient<UbicationHistorySearcher>();

            services.AddTransient<IVehicleRepository, EFVehicleRepository>();
            services.AddTransient<IDriverRepository, EFDriverRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<IUbicationHistoryRepository, EFUbicationHistoryRepository>();

            return services;
        }
    }
}
