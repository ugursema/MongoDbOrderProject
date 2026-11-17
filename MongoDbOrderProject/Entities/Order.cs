using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbOrderProject.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
