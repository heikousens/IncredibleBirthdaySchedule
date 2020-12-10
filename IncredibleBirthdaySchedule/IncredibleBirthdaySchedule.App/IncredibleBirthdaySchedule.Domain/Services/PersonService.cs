using IncredibleBirthdaySchedule.Domain.Entities;
using IncredibleBirthdaySchedule.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using IncredibleBirthdaySchedule.Domain.Interfaces.Services;

namespace IncredibleBirthdaySchedule.Domain.Services
{
    public class PersonService: IRegisterPerson, IListPerson, IUpdatePerson, IDeletePerson
    {
        private readonly IPersonRepository _repository;
        Calendar calendar = new GregorianCalendar();

        public PersonService(IPersonRepository repository)
        {
            this._repository = repository;
        }

        public void RegisterPerson(Person person)
        {
            if (person.FirstName == "" || person.LastName == "")
                return;

            try
            {
                person.Birthday = new DateTime(person.Year, person.Month, person.Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid date!");
                Console.WriteLine("");
                Console.WriteLine("See details below:");
                Console.WriteLine("");
            }
            if (person.Year > DateTime.Today.Year || person.Year < calendar.MinSupportedDateTime.Year)
            {
                Console.WriteLine("Invalid year number");
                Console.WriteLine("");
                return;

            }
            else
            {

                if (person.Month < 1 || person.Month > calendar.GetMonthsInYear(person.Year))
                {
                    Console.WriteLine("Invalid month number");
                    Console.WriteLine("");
                    return;
                }
                else
                {
                    if (person.Day <= 0 || person.Day > DateTime.DaysInMonth(person.Year, person.Month))
                    {
                        Console.WriteLine("Invalid day number");
                        Console.WriteLine("");
                        return;
                    }
                }
            } 
                        


            person.Id = Guid.NewGuid();
            _repository.Create(person);
        }

        public void EditPerson(Person person)
        {
            try
            {
                person.Birthday = new DateTime(person.Year, person.Month, person.Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid date!");
                Console.WriteLine("");
                Console.WriteLine("See details below:");
                Console.WriteLine("");
            }
            if (person.Year > DateTime.Today.Year || person.Year < calendar.MinSupportedDateTime.Year)
            {
                Console.WriteLine("Invalid year number");
                Console.WriteLine("");
                return;

            }
            else
            {

                if (person.Month < 1 || person.Month > calendar.GetMonthsInYear(person.Year))
                {
                    Console.WriteLine("Invalid month number");
                    Console.WriteLine("");
                    return;
                }
                else
                {
                    if (person.Day <= 0 || person.Day > DateTime.DaysInMonth(person.Year, person.Month))
                    {
                        Console.WriteLine("Invalid day number");
                        Console.WriteLine("");
                        return;
                    }
                }
            }
            _repository.Update(person);
        }

        public IEnumerable<Person> GetAllBirthdays()
        {
            return _repository.ListAll();
        }

        public void DeletePerson(Guid id)
        {
            _repository.Delete(id);
        }

    }
}
