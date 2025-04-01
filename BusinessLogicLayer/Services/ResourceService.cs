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
    public class ResourceService : IResource
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Resource resource)
        {
            resource.CreatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Resource>().InsertAsync(resource);
            await _unitOfWork.GetRepository<Resource>().SaveAsync();
        }

        public async Task Delete(int id)
        {
            var resource = await _unitOfWork.GetRepository<Resource>().Entities.FirstOrDefaultAsync(x => x.ResourceId == id);
            if (resource != null)
            {
                resource.DeleteAt = DateTime.Now;
                await _unitOfWork.GetRepository<Resource>().UpdateAsync(resource);
                await _unitOfWork.GetRepository<Resource>().SaveAsync();
            }
        }

        public async Task<List<Resource>> Get()
        {
            return await _unitOfWork.GetRepository<Resource>().Entities.Where(x => !x.DeleteAt.HasValue).Include(x => x.Course).AsNoTracking().ToListAsync();
        }

        public async Task<Resource?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<Resource>().Entities.Include(x => x.Course).AsNoTracking().FirstOrDefaultAsync(x => x.ResourceId == id && !x.DeleteAt.HasValue);
        }

        public async Task<List<Resource>> GetByCourseId(int courseId)
        {
            return await _unitOfWork.GetRepository<Resource>().Entities.Where(x => !x.DeleteAt.HasValue && x.CourseId == courseId).Include(x => x.Course).AsNoTracking().ToListAsync();
        }

        public async Task Update(Resource resource)
        {
            resource.UpdatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Resource>().UpdateAsync(resource);
            await _unitOfWork.GetRepository<Resource>().SaveAsync();
        }
    }

}
