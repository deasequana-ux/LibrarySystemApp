using MongoDB.Driver;
using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;

//string connectionString = "mongodb://localhost:27017";
//string databaseName = "LibrarySystem";
//string collectionName = "author";

//var client = new MongoClient(connectionString);
//var db = client.GetDatabase(databaseName);
//var collection = db.GetCollection<AuthorModel>(collectionName);


//var author = new AuthorModel { Author_Name = "Hilal", Author_Surname = "Yüce", Nationality = "Turkey", Gender = "Female", Email = "hilal@gmail.com" };

//await collection.InsertOneAsync(author);

//var results = await collection.FindAsync(_ => true); //return every record

//foreach(var result in results.ToList())
//{
//    Console.WriteLine(value:$"{result.AuthorId}: {result.Author_Name}: {result.Author_Name}: {result.Nationality}: {result.Gender}: {result.Email}:");
//}

BookDataAccess db = new BookDataAccess();

await db.CreateAuthor(author: new AuthorModel() { Author_Name = "Hilal", Author_Surname = "Yüce", Nationality = "Turkey", Gender = "Female", Email = "hilal@gmail.com" });

var authors = await db.GetAllAuthors();

var book = new BookModel()
{
    AuthorInfo = authors.First(),
    ISBN_NO = 123,
    Book_Name = "Yıldım",
    Page_Number = 320,
    Language = "Türkçe",
    Category = "Biyografi",
    Number_Of_Book = 3,
};

await db.CreateBook(book);