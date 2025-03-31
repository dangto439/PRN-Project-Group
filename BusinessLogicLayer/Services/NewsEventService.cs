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
    public class NewsEventService : INewsEvent
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsEventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(NewsEvent newsEvent)
        {
            newsEvent.CreatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<NewsEvent>().InsertAsync(newsEvent);
            await _unitOfWork.GetRepository<NewsEvent>().SaveAsync();
        }

        public async Task Delete(int id)
        {
            var newsEvent = await _unitOfWork.GetRepository<NewsEvent>().Entities.FirstOrDefaultAsync(x => x.NewsId == id);
            if (newsEvent != null)
            {
                newsEvent.DeleteAt = DateTime.Now;
                await _unitOfWork.GetRepository<NewsEvent>().UpdateAsync(newsEvent);
                await _unitOfWork.GetRepository<NewsEvent>().SaveAsync();
            }
        }

        public async Task<List<NewsEvent>> Get()
        {
            return await _unitOfWork.GetRepository<NewsEvent>().Entities.Where(x => !x.DeleteAt.HasValue).ToListAsync();
        }

        public async Task<NewsEvent?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<NewsEvent>().Entities.FirstOrDefaultAsync(x => x.NewsId == id && !x.DeleteAt.HasValue);
        }

        public async Task Update(NewsEvent newsEvent)
        {
            newsEvent.UpdatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<NewsEvent>().UpdateAsync(newsEvent);
            await _unitOfWork.GetRepository<NewsEvent>().SaveAsync();
        }
    }

}
