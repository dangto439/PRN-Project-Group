using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProject
    {
        Task<List<Project>> Get();
        Task<Project> GetById(int id);
        Task Create(Project user);
        Task Update(Project user);
        Task Delete(int id);
        Task<int> CoutProject();
    }
}
