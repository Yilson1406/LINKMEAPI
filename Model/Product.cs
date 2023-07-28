using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Model
{
    public class Product
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string UPC { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Price { get; set; } 
        public int Stock { get; set; }
        public string Mfgr { get; set; }
    }
}
