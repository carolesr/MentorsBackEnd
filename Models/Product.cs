using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MentorsBackEnd.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdProduct { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }

    }
}
