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
    public class ProjectService : IProject
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Project project)
        {
            project.CreatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Project>().InsertAsync(project);
            await _unitOfWork.GetRepository<Project>().SaveAsync();
        }

        public async Task Delete(int id)
        {
            var project = await _unitOfWork.GetRepository<Project>().Entities.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (project != null)
            {
                project.DeleteAt = DateTime.Now;
                await _unitOfWork.GetRepository<Project>().UpdateAsync(project);
                await _unitOfWork.GetRepository<Project>().SaveAsync();
            }
        }

        public async Task<List<Project>> Get()
        {
            return await _unitOfWork.GetRepository<Project>().Entities.Where(x => !x.DeleteAt.HasValue).ToListAsync();
        }

        public async Task<Project?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<Project>().Entities.FirstOrDefaultAsync(x => x.ProjectId == id && !x.DeleteAt.HasValue);
        }

        public async Task Update(Project project)
        {
            project.UpdatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Project>().UpdateAsync(project);
            await _unitOfWork.GetRepository<Project>().SaveAsync();
        }
    }

}
