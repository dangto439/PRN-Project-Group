using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ProjectService : IProject
    {
        public Task Create(Project user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Project user)
        {
            throw new NotImplementedException();
        }
    }
}
