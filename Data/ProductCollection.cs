using LINKME.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Data
{
    public class ProductCollection : IProductCollecion
    {

        internal MongoConeccion _coneccion = new MongoConeccion();
        private IMongoCollection<Product> Collection;

        public ProductCollection()
        {
            Collection = _coneccion.db.GetCollection<Product>("Products");
        }

        public async Task DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s._id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertPorduct(Product product)
        {
            await Collection.InsertOneAsync(product);
        }

        public async Task UpdateProduct(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(s => s._id, product._id);

            await Collection.ReplaceOneAsync(filter, product);

        }
    }
}
