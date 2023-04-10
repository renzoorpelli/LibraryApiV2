namespace StockService.Infrastructure.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool Commit();

        void Dispose();
        
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            if (context.ChangeTracker.HasChanges())
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
