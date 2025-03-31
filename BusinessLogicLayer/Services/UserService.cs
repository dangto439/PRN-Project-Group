using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUser
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(User user)
        {
            user.CreatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<User>().InsertAsync(user);
            await _unitOfWork.GetRepository<User>().SaveAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _unitOfWork.GetRepository<User>().Entities.FirstOrDefaultAsync(x => x.UserId == id);
            if (user != null)
            {
                user.DeleteAt = DateTime.Now;
                await _unitOfWork.GetRepository<User>().UpdateAsync(user);
                await _unitOfWork.GetRepository<User>().SaveAsync();
            }

        }

        public async Task<List<User>> Get()
        {
            return await _unitOfWork.GetRepository<User>().Entities.Where(x => !x.DeleteAt.HasValue).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.GetRepository<User>().Entities.FirstOrDefaultAsync(x => x.UserId == id && !x.DeleteAt.HasValue);
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _unitOfWork.GetRepository<User>().Entities.FirstOrDefaultAsync(x => (x.Username == username && x.Password == password) || (x.Email == username && x.Password == password));
            return user;
        }

        public async Task Update(User user)
        {
            user.UpdatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<User>().UpdateAsync(user);
            await _unitOfWork.GetRepository<User>().SaveAsync();
        }

        public async Task<int> CoutUser()
        {
            return await _unitOfWork.GetRepository<User>().Entities.Where(x => !x.DeleteAt.HasValue).CountAsync();
        }
        public async Task<int> CoutLecturer()
        {
            return await _unitOfWork.GetRepository<User>().Entities.Where(x => !x.DeleteAt.HasValue && x.Role == "LECTURER").CountAsync();
        }
        public async Task<int> CoutCustomer()
        {
            return await _unitOfWork.GetRepository<User>().Entities.Where(x => !x.DeleteAt.HasValue && x.Role == "CUSTOMER").CountAsync();
        }
    }
}
