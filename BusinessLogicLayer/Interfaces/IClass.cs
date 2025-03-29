using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IClass
    {
        Task<List<Class>> Get();
        Task<Class> GetById(int id);
        Task Create(Class user);
        Task Update(Class user);
        Task Delete(int id);
    }
}
