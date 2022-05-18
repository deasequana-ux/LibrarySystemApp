using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAccess.Models
{
    public class AuthorModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; }
        public string Author_Name { get; set; }
        public string Author_Surname { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
