using Domain.UbicationHistories;
using Domain.UbicationHistories.Predicates;

namespace Application.UbicationHistories.Search
{
    public class UbicationHistorySearcher
    {
        private readonly IUbicationHistoryRepository repository;

        public UbicationHistorySearcher(IUbicationHistoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<UbicationHistorySearcherResponse>> ExecuteAsync(UbicationHistorySearcherRequest request)
        {
            List<UbicationHistory> ubications = await repository.Search(new UbicationHistorysPredicates(request.VehicleId, request.CretedDate).CreateExpression());
            return ubications.ConvertAll(ubication => new UbicationHistorySearcherResponse(ubication.VehicleId, ubication.Ubication, ubication.CreatedDate));
        }
    }
}
