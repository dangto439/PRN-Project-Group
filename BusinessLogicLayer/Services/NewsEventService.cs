using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class NewsEventService : INewsEvent
    {
        public Task Create(NewsEvent user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsEvent>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<NewsEvent> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(NewsEvent user)
        {
            throw new NotImplementedException();
        }
    }
}
