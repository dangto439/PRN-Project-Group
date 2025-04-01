using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IContact
    {
        Task<List<Contact>> Get();
        Task<List<Contact>> GetByEmail(string email);
        Task<Contact> GetById(int id);
        Task Create(Contact user);
        Task Update(Contact user);
        Task Delete(int id);
    }
}
