using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Report.Application.Repositories.Abstract;
using Shared.Settings;
using System.Linq.Expressions;

namespace Report.Persistence.Repositories
{
    public abstract class MongoGenericRepository<T> : IMongoGenericRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly MongoDbSettings _mongoDbSettings;
        public MongoGenericRepository(IOptions<MongoDbSettings> options)
        {
            _mongoDbSettings = options.Value;
            // connectionString
            var client = new MongoClient(_mongoDbSettings.MongoDB);
            var db = client.GetDatabase(_mongoDbSettings.Database);

            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            Collection.FindOneAndDelete(predicate);
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllById(Expression<Func<T, bool>> predicate)
        {
            return await Collection.Find(predicate).ToListAsync();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return Collection.AsQueryable();
        }

        public async Task InsertAsync(T entity)
        {
          await  Collection.InsertOneAsync(entity);
        }

        public async Task BulkInsert(List<T> entity)
        {
           await Collection.InsertManyAsync(entity);
        }
        public async Task Update(T entity, Expression<Func<T, bool>> predicate)
        {
           await Collection.FindOneAndReplaceAsync(predicate, entity);
        }
    }
}