using System.Threading;
using System.Threading.Tasks;
using KweetService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KweetService.Data.Context
{
    public interface IDataContext
    {
        DbSet<KweetEntity> Kweets { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class DataContext : DbContext, IDataContext
    {
        public DbSet<KweetEntity> Kweets { get; set; }
        
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}