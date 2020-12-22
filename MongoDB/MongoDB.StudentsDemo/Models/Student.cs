namespace MongoDB.StudentsDemo.Models
{
    using MongoDB.Data.Attributes;
    using MongoDB.Data.Documents;

    [BsonCollectionAttribute("students")]
    public class Student : Document
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
