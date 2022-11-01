namespace Domain.Vehicles.Exceptions
{
    public class VehicleNotFound : Exception
    {
        public VehicleNotFound(Guid id) : base($"The vehicle with identifier {id} is not found") { }
    }
}
