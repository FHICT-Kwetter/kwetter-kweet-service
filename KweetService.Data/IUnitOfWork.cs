namespace KweetService.Data
{
    using KweetService.Data.Repositories;

    public interface IUnitOfWork
    {
        IKweetRepository Kweets { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public IKweetRepository Kweets { get; }

        public UnitOfWork()
        {
            this.Kweets = new KweetRepository();
        }
    }
}