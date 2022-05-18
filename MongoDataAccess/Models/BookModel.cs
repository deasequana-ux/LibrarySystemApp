using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDataAccess.Models
{
    public class BookModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookId { get; set; }
        public int ISBN_NO { get; set; }
        public string Book_Name { get; set; }
        public int Page_Number { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public int Number_Of_Book { get; set; }
        public AuthorModel? AuthorInfo { get; set; }

        //publisher_id,author_id
    }
}
