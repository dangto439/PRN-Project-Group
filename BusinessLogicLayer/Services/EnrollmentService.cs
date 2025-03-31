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
    public class EnrollmentService : IEnrollment
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Enrollment enrollment)
        {
            enrollment.CreatedAt = DateTime.Now;
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

        public async Task<List<Enrollment>> Get()
        {
            return await _unitOfWork.GetRepository<Enrollment>().Entities.Where(x => !x.DeleteAt.HasValue).ToListAsync();
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
    }
}
