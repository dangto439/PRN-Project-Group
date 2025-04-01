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
        Task<Enrollment> GetByCourseId(int courseId);
        Task Create(Enrollment user);
        Task Update(Enrollment user);
        Task UpdateProgress(int courseId);
        Task Delete(int id);
    }
}
