using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MentorsBackEnd.Models
{
    public class Cart
    {
        [BsonElement("id_product")]
        public string IdProduct { get; set; }

        [BsonElement("quantity")]
        public int Quantity{ get; set; }
    }
}
