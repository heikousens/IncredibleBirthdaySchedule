using System;
using System.Collections.Generic;
using System.Text;

namespace IncredibleBirthdaySchedule.Domain.Interfaces.Repositories
{
    public interface IDeletePerson
    {
        void DeletePerson(Guid id);
    }
}
