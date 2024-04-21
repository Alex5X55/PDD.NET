﻿using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Common;
using PDD.NET.Persistence;

namespace PDD.NET.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DatabaseContext Context;

    public BaseRepository(DatabaseContext context)
    {
        Context = context;
    }

    public virtual void Create(T entity)
    {
        Context.Add(entity);
    }

    public virtual void Update(T entity)
    {
        Context.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        entity.IsDeleted = true;
        Context.Update(entity);
    }

    public virtual Task<T> Get(int id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
    }

    public virtual Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return Context.Set<T>().Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
    }
}