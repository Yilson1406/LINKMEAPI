using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Data
{
    public class MongoConeccion
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoConeccion()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("LINKME");
        }
    }
}
