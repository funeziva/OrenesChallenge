using Domain.UbicationHistories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.UbicationHistorys
{
    public class EFUbicationHistoryRepository : IUbicationHistoryRepository
    {
        private readonly ApplicationContext context;

        public EFUbicationHistoryRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<UbicationHistory>> Search(Expression<Func<UbicationHistory, bool>> expression)
        {
            return await context.UbicationHistories.AsQueryable().Where(expression).ToListAsync();
        }
    }
}
