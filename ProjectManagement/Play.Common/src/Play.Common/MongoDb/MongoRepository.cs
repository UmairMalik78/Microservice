// using System;
// using System.Collections.Generic;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// using MongoDB.Driver;

// namespace Play.Common.MongoDB
// {
//     public class MongoRespository<T> : IRepository<T> where T : IEntity
//     {
//         private readonly IMongoCollection<T> dbCollection;
//         private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

//         public MongoRespository(IMongoDatabase database, string collectionName)
//         {
//             // var mongoClient = new MongoClient("mongodb://localhost:27017");
//             // var database = mongoClient.GetDatabase("Accounts");
//             dbCollection = database.GetCollection<T>(collectionName);
//         }
//         public async Task<IReadOnlyCollection<T>> GetAllAsync()
//         {
//             return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
//         }
//         public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
//         {
//             return await dbCollection.Find(filter).ToListAsync();
//         }


//         public async Task<T> GetAsync(Guid id)
//         {
//             FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
//             return await dbCollection.Find(filter).FirstOrDefaultAsync();
//         }
//         public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
//         {
//             return await dbCollection.Find(filter).FirstOrDefaultAsync();
//         }
//         // public async Task<T> GetAsync(string username, string password)
//         // {
//         //     return await dbCollection.Find(entity => entity.Username == username && entity.Password == password).FirstOrDefaultAsync();
//         // }
//         public async Task CreateAsync(T entity)
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException(nameof(entity));
//             }
//             await dbCollection.InsertOneAsync(entity);
//         }
//         public async Task UpdateAsync(T entity)
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException(nameof(entity));
//             }
//             FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
//             await dbCollection.ReplaceOneAsync(filter, entity);
//         }

//         public async Task RemoveAsync(Guid id)
//         {
//             FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
//             await dbCollection.DeleteOneAsync(filter);
//         }
//         public async Task RemoveAsync(Expression<Func<T, bool>> filter)
//         {
//             await dbCollection.DeleteOneAsync(filter);
//         }


//     }
// }