using IncredibleBirthdaySchedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncredibleBirthdaySchedule.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        void Create(Person person);
        IEnumerable<Person> ListAll();
        void Update(Person person);
        void Delete(Guid id);
    }
}
