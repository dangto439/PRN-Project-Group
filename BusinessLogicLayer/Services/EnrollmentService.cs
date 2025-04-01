using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entity;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EnrollmentService : IEnrollment
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IResource _resource;

        public EnrollmentService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IResource resource)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _resource = resource;
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

        public async Task Create(Enrollment enrollment)
        {
            enrollment.CreatedAt = DateTime.Now;
            enrollment.EnrollmentDate = DateTime.Now;
            await _unitOfWork.GetRepository<Enrollment>().InsertAsync(enrollment);
            await _unitOfWork.GetRepository<Enrollment>().SaveAsync();
        }

        public async Task Delete(int id)
        {
            var enrollment = await _unitOfWork.GetRepository<Enrollment>().Entities.FirstOrDefaultAsync(x => x.EnrollmentId == id);
            if (enrollment != null)
            {
                enrollment.DeleteAt = DateTime.Now;
                await _unitOfWork.GetRepository<Enrollment>().UpdateAsync(enrollment);
                await _unitOfWork.GetRepository<Enrollment>().SaveAsync();
            }
        }

        public async Task<List<Enrollment>?> Get()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return null;
            }
            return await _unitOfWork.GetRepository<Enrollment>().Entities.Where(x => !x.DeleteAt.HasValue && x.StudentId == userId).ToListAsync();
        }

        public async Task<Enrollment?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<Enrollment>().Entities.FirstOrDefaultAsync(x => x.EnrollmentId == id && !x.DeleteAt.HasValue);
        }

        public async Task Update(Enrollment enrollment)
        {
            enrollment.UpdatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Enrollment>().UpdateAsync(enrollment);
            await _unitOfWork.GetRepository<Enrollment>().SaveAsync();
        }

        public async Task UpdateProgress(int courseId)
        {
            var resourceList = await _resource.GetByCourseId(courseId);
            int resourceCount = resourceList.Count();

            if (resourceCount == 0)
            {
                return;
            }

            var userId = GetCurrentUserId();
            var enrollment = await _unitOfWork.GetRepository<Enrollment>().Entities.FirstOrDefaultAsync(x => !x.DeleteAt.HasValue && x.StudentId == userId && x.CourseId == courseId);
            var percent = 100 / resourceCount;
            if (enrollment.Progress < 100)
            {
                enrollment.Progress += percent;
            }
            await _unitOfWork.GetRepository<Enrollment>().UpdateAsync(enrollment);
            await _unitOfWork.GetRepository<Enrollment>().SaveAsync();
        }

        public async Task<Enrollment> GetByCourseId(int courseId)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return null;
            }
            return await _unitOfWork.GetRepository<Enrollment>().Entities.FirstOrDefaultAsync(x => !x.DeleteAt.HasValue && x.StudentId == userId && x.CourseId == courseId);
        }
    }
}
