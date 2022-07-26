namespace CDShopApp.Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly CDContext _ctx;

    public UnitOfWork(CDContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        return await _ctx.SaveEntitiesAsync(cancellationToken);
    }
}