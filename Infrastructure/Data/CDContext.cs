using Microsoft.EntityFrameworkCore;
using CDShopApp.Domain;
using CDShopApp.Infrastructure.Data.CDModel.EntityConfigurations;
using CDShopApp.Infrastructure.UoW;

namespace CDShopApp.Infrastructure;

public class CDContext : DbContext, IUnitOfWork
{
    public CDContext(DbContextOptions<CDContext> options) : base(options)
    {
    }

    public DbSet<CD> CD { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new CDMap());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        return true;
    }
}

