using Core;
using Core.Domain.Entities;
using Core.Services.Abstraction;

namespace Infrastructure.Services.Implementations
{
    /// <summary>
    /// تطبيق خدمة إدارة Offices
    /// </summary>
    public class OfficeService : IOfficeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OfficeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Office> AddOfficeAsync(Office office)
        {
            await _unitOfWork.GetRepository<Office, int>().AddAsync(office);
            await _unitOfWork.SaveChangesAsync();
            return office;
        }

        public async Task<Office?> GetOfficeByIdAsync(int officeId)
        {
            return await _unitOfWork
                .GetRepository<Office, int>()
                .GetByIdAsync(officeId);
        }

        public async Task<IEnumerable<Office>> GetAllOfficesAsync()
        {
            return await _unitOfWork
                .GetRepository<Office, int>()
                .GetAllAsync(true);
        }

        public async Task UpdateOfficeAsync(Office office)
        {
            _unitOfWork.GetRepository<Office, int>().Update(office);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteOfficeAsync(int officeId)
        {
            var office = await GetOfficeByIdAsync(officeId);
            if (office == null)
                throw new Exception($"المكتب برقم {officeId} غير موجود.");

            _unitOfWork.GetRepository<Office, int>().Delete(office);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
