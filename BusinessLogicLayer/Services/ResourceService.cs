using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ResourceService : IResource
    {
        public Task Create(Resource user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Resource>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Resource> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Resource user)
        {
            throw new NotImplementedException();
        }
    }
}
