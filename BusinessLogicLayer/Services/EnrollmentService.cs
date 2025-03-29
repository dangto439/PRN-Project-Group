using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EnrollmentService : IEnrollment
    {
        public Task Create(Enrollment user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Enrollment>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Enrollment user)
        {
            throw new NotImplementedException();
        }
    }
}
