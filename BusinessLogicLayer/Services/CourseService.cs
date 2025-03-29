using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CourseService : ICourse
    {
        public Task Create(Course user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Course user)
        {
            throw new NotImplementedException();
        }
    }
}
