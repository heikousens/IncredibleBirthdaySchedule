using IncredibleBirthdaySchedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncredibleBirthdaySchedule.Domain.Interfaces.Repositories
{
    public interface IBirthdayMathService
    {
        void BirthdayPeople();
        IEnumerable<Person> ListBirthdays(DateTime date);
        void RemainingDays(Person person);
    }
}
