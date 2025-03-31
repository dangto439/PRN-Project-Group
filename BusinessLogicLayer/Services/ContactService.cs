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
    public class ContactService : IContact
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Contact contact)
        {
            contact.CreatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Contact>().InsertAsync(contact);
            await _unitOfWork.GetRepository<Contact>().SaveAsync();
        }

        public async Task Delete(int id)
        {
            var contact = await _unitOfWork.GetRepository<Contact>().Entities.FirstOrDefaultAsync(x => x.ContactId == id);
            if (contact != null)
            {
                contact.DeleteAt = DateTime.Now;
                await _unitOfWork.GetRepository<Contact>().UpdateAsync(contact);
                await _unitOfWork.GetRepository<Contact>().SaveAsync();
            }
        }

        public async Task<List<Contact>> Get()
        {
            return await _unitOfWork.GetRepository<Contact>().Entities.Where(x => !x.DeleteAt.HasValue).ToListAsync();
        }

        public async Task<Contact?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<Contact>().Entities.FirstOrDefaultAsync(x => x.ContactId == id && !x.DeleteAt.HasValue);
        }

        public async Task Update(Contact contact)
        {
            contact.UpdatedAt = DateTime.Now;
            await _unitOfWork.GetRepository<Contact>().UpdateAsync(contact);
            await _unitOfWork.GetRepository<Contact>().SaveAsync();
        }
    }
}
