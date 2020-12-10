using IncredibleBirthdaySchedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncredibleBirthdaySchedule.Domain.Interfaces.Repositories
{
    public interface IRegisterPerson
    {
        void RegisterPerson(Person person);
    }
}
