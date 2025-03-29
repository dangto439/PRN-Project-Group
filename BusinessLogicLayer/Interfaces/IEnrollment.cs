using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEnrollment
    {
        Task<List<Enrollment>> Get();
        Task<Enrollment> GetById(int id);
        Task Create(Enrollment user);
        Task Update(Enrollment user);
        Task Delete(int id);
    }
}
