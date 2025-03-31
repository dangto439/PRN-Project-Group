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
    public class CourseService : ICourse
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Course course)
        {
            course.CreatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Course>().InsertAsync(course);
            await _unitOfWork.GetRepository<Course>().SaveAsync();
        }

        public async Task Delete(int id)
        {
            var course = await _unitOfWork.GetRepository<Course>().Entities.FirstOrDefaultAsync(x => x.CourseId == id);
            if (course != null)
            {
                course.DeleteAt = DateTime.Now;
                await _unitOfWork.GetRepository<Course>().UpdateAsync(course);
                await _unitOfWork.GetRepository<Course>().SaveAsync();
            }
        }

        public async Task<List<Course>> Get()
        {
            return await _unitOfWork.GetRepository<Course>().Entities.Where(x => !x.DeleteAt.HasValue).ToListAsync();
        }

        public async Task<Course?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<Course>().Entities.FirstOrDefaultAsync(x => x.CourseId == id && !x.DeleteAt.HasValue);
        }

        public async Task Update(Course course)
        {
            course.UpdatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Course>().UpdateAsync(course);
            await _unitOfWork.GetRepository<Course>().SaveAsync();
        }

        public async Task<int> CountCourse()
        {
            return await _unitOfWork.GetRepository<Course>().Entities.Where(x => !x.DeleteAt.HasValue).CountAsync();
        }
    }
}
