using IncredibleBirthdaySchedule.Domain.Entities;
using IncredibleBirthdaySchedule.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncredibleBirthdaySchedule.Domain.Services
{
    public class BirthdayMathService
    {
        private readonly IPersonRepository _repository;
        public BirthdayMathService(IPersonRepository repository)
        {
            this._repository = repository;
        }
        public void BirthdayPeople()
        {
            DateTime today = DateTime.Today;
            var birthdayToday = ListBirthdays(today);
            if (birthdayToday.Count() == 0)
            {
                Console.WriteLine("No birthdays today :(");
            }
            else
            {
                foreach (var pessoa in birthdayToday)
                {
                    Console.WriteLine(pessoa.FirstName + " " + pessoa.LastName + " - " + pessoa.Birthday);
                    Console.WriteLine("Hooray! Say something nice to " + pessoa.FirstName + " on this special day!");
                    Console.WriteLine("");
                }
            }
        }

        public void RemainingDays(Person person)
        {
            DateTime today = DateTime.Today;
            DateTime nextBDay = person.Birthday.AddYears(today.Year - person.Birthday.Year);

            if (nextBDay < today)
                nextBDay = nextBDay.AddYears(1);

            int DaysRemain = (nextBDay - today).Days;

            Console.WriteLine("Days remaining until next Birthday: " + DaysRemain);
            Console.WriteLine("");
            if (DaysRemain == 0)
            {
                Console.WriteLine("It's Today!! Wish " + person.FirstName + " a happy birthday!");
                Console.WriteLine("");
            }
        }


        public IEnumerable<Person> ListBirthdays(DateTime data)
        {
            return (from x in _repository.ListAll()
                    where x.Birthday.Day == data.Day && x.Birthday.Month == data.Month
                    orderby x.Birthday
                    select x);
        }
    }
}
