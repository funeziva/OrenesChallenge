namespace API.Controllers.UbicationHistories.Search
{
    public record UbicationHistorySearchRequest(Guid? VehicleId, DateTime? CretedDate);
}
