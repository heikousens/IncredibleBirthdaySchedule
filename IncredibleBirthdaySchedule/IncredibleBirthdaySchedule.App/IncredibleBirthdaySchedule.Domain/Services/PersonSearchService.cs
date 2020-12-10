using IncredibleBirthdaySchedule.Domain.Entities;
using IncredibleBirthdaySchedule.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncredibleBirthdaySchedule.Domain.Services
{
    public class PersonSearchService
    {
        private readonly IPersonRepository _repository;
        public PersonSearchService(IPersonRepository repository)
        {
            this._repository = repository;
        }
        public IEnumerable<Person> SearchByName(string name)
        {
            return _repository.ListAll().Where(
                    person => person.FirstName
                        .ToLower()
                        .Contains(name.ToLower()) || person.LastName
                        .ToLower()
                        .Contains(name.ToLower()) || (person.FirstName + " " + person.LastName).ToLower().Contains(name.ToLower()));
        }
    }
}
