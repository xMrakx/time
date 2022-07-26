﻿namespace CDShopApp.Infrastructure.UoW;

public interface IUnitOfWork
{
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}