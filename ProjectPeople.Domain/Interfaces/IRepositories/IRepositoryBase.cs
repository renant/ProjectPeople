using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectPeople.Domain.Interfaces.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Get(FilterDefinition<TEntity> filter, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<TEntity>> Find(FilterDefinition<TEntity> filter, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> Delete(string id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
