namespace MongoDB.StudentsDemo.Core
{
    using System;
    using System.Linq;

    using MongoDB.Data.Repository;
    using MongoDB.StudentsDemo.Models;
    using MongoDB.StudentsDemo.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly IMongoRepository<Student> _repository;

        public Engine(IMongoRepository<Student> repository) => this._repository = repository;

        public void Run()
        {
            var command = "";
            var name = "";
            var age = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Choose command: insert, list, edit, remove or end");
                    command = Console.ReadLine();

                    switch (command.ToLower())
                    {
                        case "end":
                            {
                                Environment.Exit(0);

                                break;
                            }
                        case "insert":
                            {
                                Console.WriteLine("Insert student name:");
                                name = Console.ReadLine();

                                Console.WriteLine("Insert student age:");
                                age = int.Parse(Console.ReadLine());

                                var student = new Student
                                {
                                    Name = name,
                                    Age = age
                                };

                                this._repository.InsertOne(student);

                                break;
                            }
                        case "list":
                            {
                                var students = this._repository.AsQueryable()
                                    .ToList();

                                foreach (var student in students)
                                {
                                    Console.WriteLine($"name: {student.Name}, age: {student.Age}");
                                }

                                break;
                            }
                        case "edit":
                            {
                                Console.WriteLine("Witch student's information do you want to change:");
                                name = Console.ReadLine();

                                var student = this._repository.FindOne(x => x.Name == name);

                                Console.WriteLine("Set new name and age");
                                name = Console.ReadLine();
                                age = int.Parse(Console.ReadLine());

                                student.Name = name;
                                student.Age = age;

                                this._repository.ReplaceOne(student);

                                break;
                            }
                        case "delete":
                            {
                                Console.WriteLine("Witch student do you want to remove:");
                                name = Console.ReadLine();

                                this._repository.DeleteOne(x => x.Name == name);

                                break;
                            }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
