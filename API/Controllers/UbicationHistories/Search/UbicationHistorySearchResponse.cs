namespace API.Controllers.UbicationHistories.Search
{
    public record UbicationHistorySearchResponse(Guid VehicleId, string Ubication, DateTime CretedDate);
}
