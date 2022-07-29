using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Play.Common;
namespace Play.Common.SqlServer
{

    public class SqlRespository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext appDbContext;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;
        private readonly DbSet<T> table;


        public SqlRespository(DbContext appDbContext)
        {
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