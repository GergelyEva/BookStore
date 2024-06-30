
using BookStore.Data.Abstractions;
using BookStore.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace BookStore.Data.MongoDB
{
  public class Database : IDatabase
  {
    private readonly IMongoDatabase db;
    private readonly MongoClient client;

    public Database(IDatabaseConfiguration configuration)
    {
      this.RegisterCustomMappings();
      this.client = new MongoClient(MongoClientSettings.FromConnectionString(configuration?.ConnectionString));
      this.db = this.client.GetDatabase(configuration?.DatabaseName);
    }

    public TCollection? GetCollection<TCollection, TItem>(string Name) where TCollection : class
    {
      return this.db.GetCollection<TItem>(Name) as TCollection;
    }

    private void RegisterCustomMappings()
    {
      if (!BsonClassMap.IsClassMapRegistered(typeof(Book)))
      {
        BsonClassMap.RegisterClassMap<Book>(cm =>
        {
          cm.AutoMap();
          cm.MapMember(book => book.PublisherId)
          .SetIdGenerator(new StringObjectIdGenerator())
          .SetIdGenerator(new ObjectIdGenerator())
          .SetSerializer(new StringSerializer(BsonType.ObjectId));
          cm.MapMember(book => book.AuthorId)
          .SetIdGenerator(new StringObjectIdGenerator())
          .SetIdGenerator(new ObjectIdGenerator())
          .SetSerializer(new StringSerializer(BsonType.ObjectId));
          cm.MapIdMember(book => book.Id)
          .SetIdGenerator(new StringObjectIdGenerator())
          .SetSerializer(new StringSerializer(BsonType.ObjectId));
          cm.SetIgnoreExtraElements(true);
        });
      }
    }
  }
}
