using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICourse
    {
        Task<List<Course>> Get();
        Task<Course> GetById(int id);
        Task Create(Course user);
        Task Update(Course user);
        Task Delete(int id);
    }
}
