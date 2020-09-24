using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MentorsBackEnd.Models
{
    public class Purchase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPurchase { get; set; }

        [BsonElement("id_user")]
        public string IdUser { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("total")]
        public decimal Total { get; set; }

        [BsonElement("method")]
        public string Method { get; set; }

        [BsonElement("cart")]
        public List<Cart> Cart { get; set; }

        [BsonElement("pending")]
        public string Pending { get; set; }

    }
}
