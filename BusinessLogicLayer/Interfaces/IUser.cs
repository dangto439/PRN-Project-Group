using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUser
    {
        Task<User> Login(string username, string password);
        Task<List<User>> Get();
        Task<User> GetById(int id);
        Task Create (User user);
        Task Update (User user);
        Task Delete (int id);

        Task<int> CoutUser();
        Task<int> CoutLecturer();
        Task<int> CoutCustomer();

    }
}
