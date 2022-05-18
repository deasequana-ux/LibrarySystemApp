

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAccess.Models
{
    public class BookHistoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }  
        public string BookId { get; set; }
        public int ISBN_NO { get; set; }
        public string Book_Name { get; set; }
        public int Page_Number { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public int Number_Of_Book { get; set; }
        public AuthorModel? WhoWritten { get; set; }

        public BookHistoryModel()
        {

        }

        public BookHistoryModel(BookModel book)
        {
            BookId = book.BookId;
            ISBN_NO = book.ISBN_NO;
            Book_Name = book.Book_Name;
            Page_Number = book.Page_Number;
            Language = book.Language;
            Category = book.Category;
            Number_Of_Book = book.Number_Of_Book;
            WhoWritten = book.AuthorInfo;
        }   
    }
}
