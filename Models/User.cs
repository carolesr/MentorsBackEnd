using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MentorsBackEnd.Models
{
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUser { get; set; }

        [BsonElement("id_card")]
        public int IdCard { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }
    }
}
