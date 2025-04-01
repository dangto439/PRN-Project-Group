using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class CourseService : ICourse
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CourseService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        private int? GetCurrentUserId()
        {
            var userIdString = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out int userId))
            {
                return userId;
            }
            return null;
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
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return await _unitOfWork.GetRepository<Course>().Entities.Where(x => !x.DeleteAt.HasValue).ToListAsync();
            }
            else
            {
                var enrollmentList = await _unitOfWork.GetRepository<Enrollment>().Entities
                                                                                    .Where(x => !x.DeleteAt.HasValue && x.StudentId == userId)
                                                                                    .Select(x => x.CourseId)
                                                                                    .ToListAsync();
                return await _unitOfWork.GetRepository<Course>().Entities
                                                                .Where(x => !x.DeleteAt.HasValue && !enrollmentList.Contains(x.CourseId))
                                                                .ToListAsync();
            }
        }

        public async Task<List<Course>> GetEnroll()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return null;
            }
            else
            {
                var enrollmentList = await _unitOfWork.GetRepository<Enrollment>().Entities
                                                                                    .Where(x => !x.DeleteAt.HasValue && x.StudentId == userId)
                                                                                    .Select(x => x.CourseId)
                                                                                    .ToListAsync();
                return await _unitOfWork.GetRepository<Course>().Entities
                                                                .Where(x => !x.DeleteAt.HasValue && enrollmentList.Contains(x.CourseId))
                                                                .ToListAsync();
            }    
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
