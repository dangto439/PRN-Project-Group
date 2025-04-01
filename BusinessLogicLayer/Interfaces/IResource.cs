using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IResource
    {
        Task<List<Resource>> Get();
        Task<List<Resource>> GetByCourseId(int courseId);
        Task<Resource> GetById(int id);
        Task Create(Resource user);
        Task Update(Resource user);
        Task Delete(int id);
    }
}
