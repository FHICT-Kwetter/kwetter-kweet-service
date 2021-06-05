using System.Threading;
using System.Threading.Tasks;
using KweetService.Data.Context;

namespace KweetService.Data
{
    using KweetService.Data.Repositories;

    public interface IUnitOfWork
    {
        IKweetRepository Kweets { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext context;
        
        public IKweetRepository Kweets { get; }

        public UnitOfWork(IDataContext context)
        {
            this.context = context;
            this.Kweets = new KweetRepository(context);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}