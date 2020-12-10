using IncredibleBirthdaySchedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncredibleBirthdaySchedule.Domain.Interfaces.Services
{
    public interface ISearchPerson
    {
        IEnumerable<Person> SearchByName(string name);
    }
}
