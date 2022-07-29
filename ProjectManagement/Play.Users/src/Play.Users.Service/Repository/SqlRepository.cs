using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Play.Common;
using Play.Users.Service.Data;

namespace Play.Users.Service.Repository
{

    public class SqlRespository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext appDbContext;
        //    private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;
        private readonly DbSet<T> table;


        public SqlRespository(DbContext appDbContext)
        {
            // var mongoClient = new MongoClient("mongodb://localhost:27017");
            // var database = mongoClient.GetDatabase("Accounts");
            this.appDbContext = appDbContext;
            this.table = (DbSet<T>)appDbContext.GetType().GetProperty(typeof(T).Name + "Table").GetValue(appDbContext);

        }
        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await table.ToArrayAsync();
        }
        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await table.Where(filter).ToArrayAsync();
        }
        public async Task<T> GetAsync(Guid id)
        {
            var item = await table.FirstOrDefaultAsync(entity => entity.Id == id);
            return item;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await table.Where(filter).FirstOrDefaultAsync();
        }
        // public async Task<T> GetAsync(string username, string password)
        // {
        //     return await dbCollection.Find(entity => entity.Username == username && entity.Password == password).FirstOrDefaultAsync();
        // }
        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await table.AddAsync(entity);
            await appDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            table.Update(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            table.Remove(await table.FirstAsync(item => item.Id == id));
            await appDbContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(Expression<Func<T, bool>> filter)
        {
            table.Remove(await table.FirstAsync(filter));
            await appDbContext.SaveChangesAsync();
        }

    }
}