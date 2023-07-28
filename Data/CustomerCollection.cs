using LINKME.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Data
{
    public class CustomerCollection : ICustomerCollecion
    {

        internal MongoConeccion _coneccion = new MongoConeccion();
        private IMongoCollection<Cuatomer> Collection;

        public CustomerCollection()
        {
            Collection = _coneccion.db.GetCollection<Cuatomer>("customer");
        }

        public async Task Deletecustomer(string id)
        {
            var filter = Builders<Cuatomer>.Filter.Eq(s => s._id,id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Cuatomer>> GetAllcustomer()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Cuatomer> GetcustomerById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
        }

        public async Task Insertcustomer(Cuatomer customer)
        {
            await Collection.InsertOneAsync(customer);
        }

        public async Task Updatecustomer(Cuatomer customer)
        {
            var filter = Builders<Cuatomer>.Filter.Eq(s => s._id, customer._id);

            await Collection.ReplaceOneAsync(filter, customer);

        }

    }
}
