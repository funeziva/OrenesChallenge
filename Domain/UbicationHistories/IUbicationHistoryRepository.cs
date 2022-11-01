using System.Linq.Expressions;

namespace Domain.UbicationHistories
{
    public interface IUbicationHistoryRepository
    {
        Task<List<UbicationHistory>> Search(Expression<Func<UbicationHistory, bool>> expression);
    }
}
