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
    public class ClassService : IClass
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Class cls)
        {
            cls.CreatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Class>().InsertAsync(cls);
            await _unitOfWork.GetRepository<Class>().SaveAsync();
        }

        public async Task Delete(int id)
        {
            var cls = await _unitOfWork.GetRepository<Class>().Entities.FirstOrDefaultAsync(x => x.ClassId == id);
            if (cls != null)
            {
                cls.DeleteAt = DateTime.Now;
                await _unitOfWork.GetRepository<Class>().UpdateAsync(cls);
                await _unitOfWork.GetRepository<Class>().SaveAsync();
            }
        }

        public async Task<List<Class>> Get()
        {
            return await _unitOfWork.GetRepository<Class>().Entities.Where(x => !x.DeleteAt.HasValue).ToListAsync();
        }

        public async Task<Class?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<Class>().Entities.FirstOrDefaultAsync(x => x.ClassId == id && !x.DeleteAt.HasValue);
        }

        public async Task Update(Class cls)
        {
            cls.UpdatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Class>().UpdateAsync(cls);
            await _unitOfWork.GetRepository<Class>().SaveAsync();
        }
    }

}
