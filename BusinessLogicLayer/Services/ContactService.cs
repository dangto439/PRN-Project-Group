using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ContactService : IContact
    {
        public Task Create(Contact user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Contact user)
        {
            throw new NotImplementedException();
        }
    }
}
