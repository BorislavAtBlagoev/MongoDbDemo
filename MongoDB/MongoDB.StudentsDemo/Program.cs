namespace MongoDB.StudentsDemo
{
    using MongoDB.Data.Settings;
    using MongoDB.Data.Repository;

    using MongoDB.StudentsDemo.Core;
    using MongoDB.StudentsDemo.Models;
    using MongoDB.StudentsDemo.Core.Contracts;

    public class Program
    {
        public static void Main()
        {
            IMongoDbSettings settings = new MongoDbSettings();
            settings.ConnectionString = "mongodb://127.0.0.1:27017";
            settings.DatabaseName = "Students";

            IMongoRepository<Student> repository = new MongoRepository<Student>(settings);

            IEngine engine = new Engine(repository);
            engine.Run();
        }
    }
}
