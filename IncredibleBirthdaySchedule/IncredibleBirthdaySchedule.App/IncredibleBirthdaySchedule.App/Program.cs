using IncredibleBirthdaySchedule.Domain.Entities;
using IncredibleBirthdaySchedule.Domain.Services;
using IncredibleBirthdaySchedule.Infrastructure.Repositories;
using System;
using System.Linq;

namespace IncredibleBirthdaySchedule.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PersonService(new TextFileRepository());
            var searchservice = new PersonSearchService(new TextFileRepository());
            var bdayService = new BirthdayMathService(new TextFileRepository());
            int option = 0;

            do
            {
                Console.WriteLine("Who's having their birthday today:\n");

                bdayService.BirthdayPeople();

                Console.WriteLine("");

                Console.WriteLine("1 - Register a New Friend");
                Console.WriteLine("2 - Edit Friend");
                Console.WriteLine("3 - See Full List of Birthdays");
                Console.WriteLine("4 - Delete Friend");
                Console.WriteLine("5 - Search Friend");
                Console.WriteLine("6 - Exit");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                Person person;

                switch (option)
                {
                    case 1:
                        person = new Person();

                        Console.WriteLine("Enter the friend's first name:");
                        person.FirstName = Console.ReadLine();

                        Console.WriteLine("Enter the friend's last name:");
                        person.LastName = Console.ReadLine();

                        Console.Write("Enter the day of the friend's birthday: ");
                        person.Day = int.Parse(Console.ReadLine());

                        Console.Write("Enter the month of the friend's birthday: ");
                        person.Month = int.Parse(Console.ReadLine());

                        Console.Write("Enter the year of the friend's birthday: ");
                        person.Year = int.Parse(Console.ReadLine());

                        service.RegisterPerson(person);
                        break;

                    case 2:
                        person = new Person();
                        Console.WriteLine("Digite o Id do contato que deseja editar");
                        person.Id = Guid.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the new first name");
                        person.FirstName = Console.ReadLine();

                        Console.WriteLine("Enter the new last name");
                        person.LastName = Console.ReadLine();

                        Console.Write("Enter the day of the friend's birthday: ");
                        person.Day = int.Parse(Console.ReadLine());

                        Console.Write("Enter the month of the friend's birthday: ");
                        person.Month = int.Parse(Console.ReadLine());

                        Console.Write("Enter the year of the friend's birthday: ");
                        person.Year = int.Parse(Console.ReadLine());

                        service.EditPerson(person);
                        break;

                    case 3:
                        var people = service.GetAllBirthdays();
                        foreach (var listedperson in people)
                        {
                            Console.WriteLine("Id: " + listedperson.Id);
                            Console.WriteLine("Name: " + listedperson.FirstName + " " + listedperson.LastName);
                            Console.WriteLine("Birthday: " + listedperson.Birthday);
                            bdayService.RemainingDays(listedperson);
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        Console.WriteLine("Digite o Id do contato que deseja remover:");
                        var id = Guid.Parse(Console.ReadLine());
                        service.DeletePerson(id);
                        break;

                    case 5:
                        Console.WriteLine("Digite o nome do contato que está procurando:");
                        var name = Console.ReadLine();
                        var searchResult = searchservice.SearchByName(name);
                        foreach (var curContact in searchResult)
                        {
                            Console.WriteLine("Id: " + curContact.Id);
                            Console.WriteLine("Name: " + curContact.FirstName + " " + curContact.LastName);
                            Console.WriteLine("Birthday: " + curContact.Birthday);
                            Console.WriteLine();
                        }
                        break;

                }

                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
                Console.Clear();

            } while (option != 6);
        }
    }
}
