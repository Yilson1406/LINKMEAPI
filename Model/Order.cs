using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Model
{
    public class Order
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime Date { get; set; }
        public string SoldBy { get; set; }
        public int Total { get; set; }
        public  List<OrderList> listproduct { get; set; }

    }
    public class OrderList
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitSalePreci { get; set; }
        public decimal subtotal { get; set; }

    }
}
