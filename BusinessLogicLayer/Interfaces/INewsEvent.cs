using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface INewsEvent
    {
        Task<List<NewsEvent>> Get();
        Task<NewsEvent> GetById(int id);
        Task Create(NewsEvent user);
        Task Update(NewsEvent user);
        Task Delete(int id);
    }
}
