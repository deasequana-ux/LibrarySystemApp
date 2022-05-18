using MongoDataAccess.Models;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess
{
    public class BookDataAccess
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "LibraryDB";
        private const string BookCollection = "books";
        private const string AuthorCollection = "authors";
        private const string BookHistoryCollection = "book_history";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<List<AuthorModel>> GetAllAuthors()
        {
            var authorsCollection = ConnectToMongo<AuthorModel>(AuthorCollection);
            var results = await authorsCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var booksCollection = ConnectToMongo<BookModel>(BookCollection);
            var results = await booksCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<List<BookModel>> GetAllBooksForAuthor(AuthorModel author)
        {
            var booksCollection = ConnectToMongo<BookModel>(BookCollection);
            var results = await booksCollection.FindAsync(c => c.AuthorInfo.AuthorId == author.AuthorId); //c.AuthorName.AuthorId --> object-subobject-property
            return results.ToList();
        }

        public Task CreateAuthor(AuthorModel author)
        {
            var authorsCollection = ConnectToMongo<AuthorModel>(AuthorCollection);
            return authorsCollection.InsertOneAsync(author);
        }

        public Task CreateBook(BookModel book)
        {
            var booksCollection = ConnectToMongo<BookModel>(BookCollection);
            return booksCollection.InsertOneAsync(book);
        }

        public Task UpdateBook(BookModel book)
        {
            var booksCollection = ConnectToMongo<BookModel>(BookCollection);
            var filter = Builders<BookModel>.Filter.Eq(field:"BookId", book.BookId); //Eq --> Equal
            return booksCollection.ReplaceOneAsync(filter, book, options:new ReplaceOptions { IsUpsert = true });
        }

        public Task DeleteBook(BookModel book)
        {
            var booksCollection = ConnectToMongo<BookModel>(BookCollection);
            return booksCollection.DeleteOneAsync(c => c.BookId == book.BookId);
        }


    }
}
