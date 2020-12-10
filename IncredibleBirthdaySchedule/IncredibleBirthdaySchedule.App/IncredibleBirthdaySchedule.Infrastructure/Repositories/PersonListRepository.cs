using IncredibleBirthdaySchedule.Domain.Entities;
using IncredibleBirthdaySchedule.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncredibleBirthdaySchedule.Infrastructure.Repositories
{
    //public class PersonListRepository : IPersonRepository
    public class PersonListRepository : IRegisterPerson, IListPerson, IUpdatePerson, IDeletePerson
    {
        private static List<Person> People = new List<Person>();

        public void RegisterPerson(Person person)
        {
            People.Add(person);
        }

        public void DeletePerson(Guid id)
        {
            var listPeople = People.Find(p => p.Id == id);
            People.Remove(listPeople);
        }

        public IEnumerable<Person> GetAllBirthdays()
        {
            return People;
        }

        public void EditPerson(Person person)
        {
            var listPeople = People.Find(p => p.Id == person.Id);

            listPeople.FirstName = person.FirstName;
            listPeople.LastName = person.LastName;
            listPeople.Day = person.Day;
            listPeople.Month = person.Month;
            listPeople.Year = person.Year;
            listPeople.Birthday = new DateTime(listPeople.Year, listPeople.Month, listPeople.Day);

        }
    }
}
