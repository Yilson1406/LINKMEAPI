using LINKME.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Data
{
    public class OrderCollection : IOrderCollecion
    {

        internal MongoConeccion _coneccion = new MongoConeccion();
        private IMongoCollection<Order> Collection;

        public OrderCollection()
        {
            Collection = _coneccion.db.GetCollection<Order>("order");
        }

        public async Task<List<Order>> GetAllorder()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Order> GetorderById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
        }

        public async Task Insertorder(Order customer)
        {
            await Collection.InsertOneAsync(customer);
        }
        public async Task Updateorder(Order customer)
        {
            var filter = Builders<Order>.Filter.Eq(s => s._id, customer._id);

            await Collection.ReplaceOneAsync(filter, customer);

        }
    }
}
