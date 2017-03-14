using MongoDB.Bson;
using MongoDB.Driver;
using ProjectPeople.Domain.Interfaces;
using ProjectPeople.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectPeople.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : IEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public RepositoryBase(MongoClient client)
        {
            var database = client.GetDatabase("mydatabase");
            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> Get(FilterDefinition<TEntity> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var model = await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<IEnumerable<TEntity>> Find(FilterDefinition<TEntity> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var model = await _collection.Find(filter).ToListAsync(cancellationToken);
            return model;
        }

        public async Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entity.Id == null)
                entity.Id = ObjectId.GenerateNewId().ToString();

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _collection.InsertOneAsync(entity, cancellationToken);
            
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            var idFilter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);

            entity.UpdatedDate = DateTime.UtcNow;

            await _collection.ReplaceOneAsync(idFilter, entity,null,cancellationToken);

            return entity;
        }

        public virtual async Task<TEntity> Delete(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _collection.FindOneAndDeleteAsync(e => e.Id == id, null, cancellationToken);
        }
    }
}
