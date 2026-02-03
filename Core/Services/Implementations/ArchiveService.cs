using Core;
using Core.Domain.Entities;
using Core.Services.Abstraction;

namespace Infrastructure.Services.Implementations
{
    /// <summary>
    /// خدمة إدارة الأرشفة
    /// </summary>
    public class ArchiveService : IArchiveService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArchiveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Archive> AddArchiveAsync(Archive archive)
        {
            await _unitOfWork.GetRepository<Archive, int>().AddAsync(archive);
            await _unitOfWork.SaveChangesAsync();
            return archive;
        }

        public async Task<IEnumerable<Archive>> GetAllArchivesAsync()
        {
            return await _unitOfWork
                .GetRepository<Archive, int>()
                .GetAllAsync(true);
        }
    }
}
