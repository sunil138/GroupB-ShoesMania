using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PaymentDetails_Mongo.Models
{
    public class Payments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? id { get; set; }
        public string? UserName { get; set; }

        public string? PaymentType { get; set; }

        public double? Amount { get; set; }

        public string? DeliveryAddress { get; set; }

        
    }
}
