﻿namespace Abstractions.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
