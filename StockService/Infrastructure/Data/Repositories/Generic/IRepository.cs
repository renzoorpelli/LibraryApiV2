using StockService.Domain.Entities;

namespace StockService.Infrastructure.Data.Repositories.Generic
{
    public interface IRepository
    {
        void Create(Book book);
        bool Delete(int idBook);
        bool Update(Book bookUpdated, int id);

        bool Check(int idBook);
    }
}
